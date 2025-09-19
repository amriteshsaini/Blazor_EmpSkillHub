using EmpSkillHub.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpSkillHub.Service.Interfaces;

public interface IEmpSkillService
{
    Task<IEnumerable<EmpSkill>> GetAllEmpSkillAsync();
    Task AddEmpSkillAsync(EmpSkill empSkill);
}
