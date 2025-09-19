using EmpSkillHub.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpSkillHub.Service.Interfaces;

public interface ISkillService
{
    Task<IEnumerable<Skill>> GetAllSkillsAsync();
    Task AddSkillsAsync(Skill skill);
}
