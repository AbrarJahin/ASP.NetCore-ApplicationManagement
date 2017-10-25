using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationManagement.DbModel
{
    public class BaseEntity
    {
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime LastModifiedDate { get; set; }

        [Key]
        public long Id { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true), Display(Name = "সংযুক্তকরণের সময়")]
        public DateTime? CreatedTime { get; set; }
        public long CreatedUserId { get; set; }
        public string CreatedIPAddress { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true), Display(Name = "শেষ হালনাগাদের সময়")]
        public DateTime? LastModifiedTime { get; set; }
        public long LastModifiedUserId { get; set; }
        public string LastModifiedIPAddress { get; set; }
    }
}
