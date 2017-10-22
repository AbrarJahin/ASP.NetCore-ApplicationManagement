using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationManagement.DbModel
{
    public class JobCircular
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string PostName { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public UInt16 NoOfTotalAvailablePosts { get; set; }

        [Required]
        public string NoticeImageFileUrl { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]

        [Required]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        public DateTime LastModifiedDate { get; set; }

        public virtual ICollection<TeacherApplication> TeacherApplications { get; set; }

        public JobCircular()
        {
            AddedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}
