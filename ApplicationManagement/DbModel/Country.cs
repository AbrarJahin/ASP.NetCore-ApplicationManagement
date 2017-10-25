using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Country
    {
        [Key]
        public long Id { get; set; }

        public long TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual TeacherApplication TeacherApplication { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        public Country()
        {
            AddedDate = DateTime.Now;
        }
    }
}
