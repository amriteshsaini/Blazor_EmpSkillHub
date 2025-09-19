using EmpSkillHub.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISkillRepository
{
    Task<List<Skill>> GetAllAsync();
    Task<Skill> GetByIdAsync(int id);
    Task AddAsync(Skill skill);
    Task<bool> ExistsAsync(string skillName);
}