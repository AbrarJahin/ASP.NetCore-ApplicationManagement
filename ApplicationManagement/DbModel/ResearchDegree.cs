using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class ResearchDegree
    {
        [Key]
        public long Id { get; set; }

        public long TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual TeacherApplication Teacher { get; set; }

        [Required]
        public string NameOfDegree { get; set; }
        [Required]
        public string SubjectOfResearch { get; set; }
        [Required]
        public string SupervisorsNameAndAddress { get; set; }
        [Required]
        public string UniversityName { get; set; }
        [Required]
        public UInt16 YearOfPassing { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        public ResearchDegree()
        {
            AddedDate = DateTime.Now;
        }
    }
}
