using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Language
    {
        [Key]
        public UInt64 Id { get; set; }
        [ForeignKey("Teacher")]
        public UInt64 TeacherId { get; set; }

        public string Name { get; set; }
        public string Skill { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        public Language()
        {
            AddedDate = DateTime.Now;
        }
    }
}
