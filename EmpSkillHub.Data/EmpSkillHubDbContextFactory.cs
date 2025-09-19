using EmpSkillHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EmpSkillHub.Data
{
    public class EmpSkillHubDbContextFactory : IDesignTimeDbContextFactory<EmpSkillHubDbContext>
    {
        public EmpSkillHubDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "EmpSkillHub.Web");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionStringName = configuration.GetValue<string>("AppSettings:UseConnection");

            var connectionString = configuration.GetConnectionString(connectionStringName);

            var optionsBuilder = new DbContextOptionsBuilder<EmpSkillHubDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EmpSkillHubDbContext(optionsBuilder.Options);
        }
    }
}