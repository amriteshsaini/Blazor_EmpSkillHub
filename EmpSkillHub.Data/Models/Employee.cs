using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpSkillHub.Data.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<EmpSkill> EmpSkills { get; set; }
    }
}