using EmpSkillHub.Data;
using EmpSkillHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EmpSkillRepository : IEmpSkillRepository
{
    private readonly EmpSkillHubDbContext _context;

    public EmpSkillRepository(EmpSkillHubDbContext context)
    {
        _context = context;
    }

    public async Task<List<EmpSkill>> GetAllAsync()
    {
        return await _context.EmpSkills
            .Include(e => e.Employee)
            .ThenInclude(es => es.EmpSkills)
            .ToListAsync();
    }

    public async Task<EmpSkill> GetByIdAsync(int id)
    {
        return await _context.EmpSkills.FindAsync(id);
    }

    public async Task AddAsync(EmpSkill empSkill)
    {
        _context.EmpSkills.Add(empSkill);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int empId, int skillId)
    {
        return await _context.EmpSkills.AnyAsync(e => e.Employee.RecId == empId && e.Skill.RecId == skillId);
    }
}
