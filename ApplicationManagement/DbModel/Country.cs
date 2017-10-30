using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Country : BaseEntity
    {
        public long TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual TeacherApplication TeacherApplication { get; set; }

        [Required]
        public string EnglishName { get; set; }

        [Required]
        public string ShortName { get; set; }

        [Required]
        public string BengaliName { get; set; }

        public UInt16 PhoneCode { get; set; }

        public virtual ICollection<CountryPerson> CountryPersons { get; set; }
    }
}
