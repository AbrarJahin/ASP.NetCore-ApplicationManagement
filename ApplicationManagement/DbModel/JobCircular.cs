using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationManagement.DbModel
{
    public class JobCircular
    {
        [Key]
        public long Id { get; set; }

        [Required, MinLength(3), MaxLength(50), Display(Name = "পদের নাম")]
        public string PostName { get; set; }

        [Required, MinLength(9), MaxLength(600), Display(Name = "চাকুরীর বিবরন")]
        public string Description { get; set; }

        [Required, Display(Name = "পদের সংখ্যা")]
        public UInt16 NoOfTotalAvailablePosts { get; set; }

        [Required, MinLength(3), MaxLength(200), Display(Name = "চাকুরীর বিজ্ঞপ্তির ছবি")]
        public string NoticeImageFileUrl { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "আবেদন শুরুর দিন")]
        public DateTime StartDate { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "আবেদনের শেষ দিন")]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true), Display(Name = "সংযুক্তকরণের সময়")]
        public DateTime AddedDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true), Display(Name = "শেষ হালনাগাদের সময়")]
        public DateTime LastModifiedDate { get; set; }

        public virtual ICollection<TeacherApplication> TeacherApplications { get; set; }

        public JobCircular()
        {
            AddedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}
