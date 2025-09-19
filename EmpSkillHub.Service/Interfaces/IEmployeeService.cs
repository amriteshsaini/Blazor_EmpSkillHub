using EmpSkillHub.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpSkillHub.Service.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task AddEmployeeAsync(Employee employee, List<int> selectedSkillIds);
}
