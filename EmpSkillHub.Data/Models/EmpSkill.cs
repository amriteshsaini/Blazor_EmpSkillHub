using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmpSkillHub.Data.Models
{
    public class EmpSkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public int EmpId { get; set; }
        public Employee Employee { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }

}