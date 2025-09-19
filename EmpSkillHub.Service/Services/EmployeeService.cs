using EmpSkillHub.Data.Models;
using EmpSkillHub.Service.Interfaces;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpSkillHub.Service.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ISkillRepository _skillRepository;
    private readonly IEmpSkillRepository _empSkillRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, ISkillRepository skillRepository)
    {
        _employeeRepository = employeeRepository;
        _skillRepository = skillRepository;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        try
        {
            return await _employeeRepository.GetAllAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Something went wrong at GetAllEmployeesAsync");
            throw new Exception("Error retrieving employees.", ex);
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public async Task AddEmployeeAsync(Employee employee, List<int> selectedSkillIds)
    {
        try
        {
            if (await _employeeRepository.ExistsAsync(employee.FirstName, employee.LastName, employee.PhoneNumber))
                throw new System.Exception("Employee with same name and phone already exists.");

            var skills = await _skillRepository.GetAllAsync();

            employee.EmpSkills = selectedSkillIds.Select(skillId => new EmpSkill
            {
                Skill = skills.Where(x => x.RecId == skillId).FirstOrDefault()
            }).ToList();
            await _employeeRepository.AddAsync(employee);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Something went wrong at AddEmployeeAsync");
            throw new Exception("Error adding employees.", ex);
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
