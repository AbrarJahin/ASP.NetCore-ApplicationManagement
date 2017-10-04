using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class ResearchDegree
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public UInt64 Id { get; set; }
        [ForeignKey("Teacher")]
        public UInt64 TeacherId { get; set; }

        public string NameOfDegree { get; set; }
        public string SubjectOfResearch { get; set; }
        public string SupervisorsNameAndAddress { get; set; }
        public string UniversityName { get; set; }
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
