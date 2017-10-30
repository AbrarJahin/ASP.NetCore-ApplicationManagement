using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class CountryPerson : BaseEntity
    {
        [Key, Column(Order = 0)]
        public int CountryID { get; set; }
        [Key, Column(Order = 1)]
        public int PersonID { get; set; }

        public virtual Country Country { get; set; }
        public virtual Person Person { get; set; }

        public string ReasonOfTour { get; set; }
    }
}
