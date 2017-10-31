using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ApplicationManagement.DbModel.CustomTypes;

namespace ApplicationManagement.DbModel
{
    public class Address : BaseEntity
    {
        //public long PersonId { get; set; }
        //[Required, ForeignKey("PersonId")]
        //public virtual Person Person { get; set; }
        //[Required]
        //public AddressType AddressType { get; set; }
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
    }
}
