using EmpSkillHub.Data;
using EmpSkillHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmpSkillHubDbContext _context;

    public EmployeeRepository(EmpSkillHubDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees
            .Include(e => e.EmpSkills)
            .ThenInclude(es => es.Skill)
            .ToListAsync();
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task AddAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(string firstName, string lastName, string phoneNumber)
    {
        return await _context.Employees.AnyAsync(e => e.FirstName == firstName && e.LastName == lastName && e.PhoneNumber == phoneNumber);
    }
}
