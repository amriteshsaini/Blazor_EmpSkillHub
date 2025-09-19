using EmpSkillHub.Data;
using EmpSkillHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SkillRepository : ISkillRepository
{
    private readonly EmpSkillHubDbContext _context;

    public SkillRepository(EmpSkillHubDbContext context)
    {
        _context = context;
    }

    public async Task<List<Skill>> GetAllAsync()
    {
        return await _context.Skills
            .Include(e => e.EmpSkills)
            .ThenInclude(es => es.Employee)
            .ToListAsync();
    }

    public async Task<Skill> GetByIdAsync(int id)
    {
        return await _context.Skills.FindAsync(id);
    }

    public async Task AddAsync(Skill Skill)
    {
        _context.Skills.Add(Skill);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(string skillName)
    {
        return await _context.Skills.AnyAsync(e => e.Name == skillName);
    }
}
