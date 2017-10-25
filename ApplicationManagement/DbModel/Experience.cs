using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ApplicationManagement.DbModel.CustomTypes;

namespace ApplicationManagement.DbModel
{
    public class Experience
    {
        [Key]
        public long Id { get; set; }

        public long TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual TeacherApplication Teacher { get; set; }

        [Required]
        public string NameOfPost { get; set; }
        [Required]
        public string NameOfOrganization { get; set; }
        [Required]
        public OrganizationType OrganizationType { get; set; }
        [Required]
        public UInt16 SalaryScale { get; set; }
        [Required]
        public UInt16 TotalSalary { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string CertificatePdfFileUrl { get; set; }

        public TimeSpan ExperienceTime { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        public Experience()
        {
            AddedDate = DateTime.Now;
            ExperienceTime = EndDate - StartDate;
        }
    }
}
