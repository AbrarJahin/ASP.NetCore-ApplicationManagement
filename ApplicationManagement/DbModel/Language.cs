using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Language : BaseEntity
    {
        public long TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual TeacherApplication Teacher { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Skill { get; set; }
    }
}
