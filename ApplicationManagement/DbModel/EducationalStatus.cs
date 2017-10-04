using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class EducationalStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public UInt64 Id { get; set; }
        [ForeignKey("Teacher")]
        public UInt64 TeacherId { get; set; }

        public string ExamName { get; set; }
        public string BoardOrUniversity { get; set; }
        public string GroupOrSubject { get; set; }
        public UInt16 YearOfPassing { get; set; }
        public UInt16 YearOfExam { get; set; }
        public string DivisionOrClassOrGPAOrCGPA { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        public EducationalStatus()
        {
            AddedDate = DateTime.Now;
        }
    }
}
