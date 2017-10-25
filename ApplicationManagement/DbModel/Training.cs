using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Training
    {
        [Key]
        public long Id { get; set; }

        public long TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual TeacherApplication Teacher { get; set; }

        [Required, MinLength(3), MaxLength(70)]
        public string Name { get; set; }
        [Required, MinLength(9), MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public TimeSpan Duration { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        public Training()
        {
            AddedDate = DateTime.Now;
            Duration = EndDate - StartDate;
        }
    }
}
