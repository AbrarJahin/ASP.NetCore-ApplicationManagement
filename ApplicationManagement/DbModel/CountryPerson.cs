using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class CountryPerson : BaseEntity
    {
        [Key, Column(Order = 0)]
        public long CountryID { get; set; }
        [Key, Column(Order = 1)]
        public long PersonID { get; set; }

        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }

        public string ReasonOfTour { get; set; }
    }
}
