using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Reference : BaseEntity
    {
        public long TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual TeacherApplication Teacher { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Identity { get; set; }
        [Required]
        public string Address { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
    }
}
