using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Address
    {
        [Key]
        public long Id { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string HoldingNoOrVillage { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string RoadBlockSector { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Thana { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string PostOffice { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string District { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        public Address()
        {
            AddedDate = DateTime.Now;
        }
    }
}
