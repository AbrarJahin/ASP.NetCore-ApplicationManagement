using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Address
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string HoldingNoOrVillage { get; set; }
        [Required]
        public string RoadBlockSector { get; set; }
        [Required]
        public string Thana { get; set; }
        [Required]
        public string PostOffice { get; set; }
        [Required]
        public string District { get; set; }
        [Phone]
        [Required]
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
