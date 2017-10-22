using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationManagement.DbModel
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        public DateTime LastModifiedDate { get; set; }

        //public string IPAddress { get; set; }

        public BaseEntity()
        {
            AddedDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
        }
    }
}
