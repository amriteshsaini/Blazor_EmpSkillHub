using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpSkillHub.Data.Models
{
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public string Name { get; set; }
        public ICollection<EmpSkill> EmpSkills { get; set; }
    }
}