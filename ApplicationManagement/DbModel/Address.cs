using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public UInt64 Id { get; set; }
        [ForeignKey("Teacher")]
        public UInt64 TeacherId { get; set; }

        public string HoldingNoOrVillage { get; set; }
        public string RoadBlockSector { get; set; }
        public string Thana { get; set; }
        public string PostOffice { get; set; }
        public string District { get; set; }
        public string PhoneNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        public Address()
        {
            AddedDate = DateTime.Now;
        }
    }
}
