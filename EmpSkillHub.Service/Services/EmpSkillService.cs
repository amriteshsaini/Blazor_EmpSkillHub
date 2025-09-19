using EmpSkillHub.Data.Models;
using EmpSkillHub.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;

namespace EmpSkillHub.Service.Services;

public class EmpSkillService : IEmpSkillService
{
    private readonly IEmpSkillRepository _empSkillRepository;

    public EmpSkillService(IEmpSkillRepository empSkillRepository)
    {
        _empSkillRepository = empSkillRepository;
    }

    public async Task<IEnumerable<EmpSkill>> GetAllEmpSkillAsync()
    {
        try
        {
            return await _empSkillRepository.GetAllAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Something went wrong at GetAllEmpSkillAsync");
            throw new Exception("Error retrieving empskills.", ex);
}
        finally
        {
            Log.CloseAndFlush();
        }
        
    }

    public async Task AddEmpSkillAsync(EmpSkill empSkill)
    {
        try
        {
            if (await _empSkillRepository.ExistsAsync(empSkill.Employee.RecId, empSkill.Skill.RecId))
                throw new System.Exception("Skill already added for this Employee.");

            await _empSkillRepository.AddAsync(empSkill);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Something went wrong at AddEmpSkillAsync");
            throw new Exception("Error adding empSkills.", ex);
        }
        finally
        {
            Log.CloseAndFlush();
        }

    }
}
