using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Research
    {
        [Key]
        public long Id { get; set; }

        public long TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual TeacherApplication Teacher { get; set; }

        [Required]
        public string NameOfPublication { get; set; }
        [Required]
        public string NameOfPublicationPaper { get; set; }
        [Required]
        public string NameOfPublicationInstitute { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfPublication { get; set; }
        [Required]
        public string EditionOfPublication { get; set; }
        public string Note { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        public Research()
        {
            AddedDate = DateTime.Now;
        }
    }
}
