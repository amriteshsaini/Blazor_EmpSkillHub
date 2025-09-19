using EmpSkillHub.Data.Models;
using EmpSkillHub.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;

namespace EmpSkillHub.Service.Services;

public class SkillService : ISkillService
{
    private readonly ISkillRepository _skillRepository;

    public SkillService(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
    {
        try
        {
            return await _skillRepository.GetAllAsync();
        }
        catch(Exception ex)
        {
            Log.Error(ex, "Something went wrong at GetAllSkillsAsync");
            throw new Exception("Error retrieving skills.", ex);
        }
        finally
        {
            Log.CloseAndFlush(); 
        }
    }

    public async Task AddSkillsAsync(Skill skill)
    {
        try
        {
            if (await _skillRepository.ExistsAsync(skill.Name))
                throw new System.Exception("Skill with same name already exists.");

            await _skillRepository.AddAsync(skill);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Something went wrong at AddSkillsAsync");
            throw new Exception("Error adding skill.", ex);
        }
        finally
        {
            Log.CloseAndFlush();
        }

    }
}
