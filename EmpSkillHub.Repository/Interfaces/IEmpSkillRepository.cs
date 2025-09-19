using EmpSkillHub.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEmpSkillRepository
{
    Task<List<EmpSkill>> GetAllAsync();
    Task<EmpSkill> GetByIdAsync(int id);
    Task AddAsync(EmpSkill skill);
    Task<bool> ExistsAsync(int empId, int skillId);
}