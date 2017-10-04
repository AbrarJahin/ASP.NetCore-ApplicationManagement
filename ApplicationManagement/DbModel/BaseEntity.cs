using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationManagement.DbModel
{
    public class BaseEntity
    {
        public UInt64 Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }

        //public string IPAddress { get; set; }

        public BaseEntity()
        {
            AddedDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
        }
    }
}
