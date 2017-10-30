using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ApplicationManagement.DbModel.CustomTypes;

namespace ApplicationManagement.DbModel
{
    public class TeacherApplication : BaseEntity
    {
        [Required]
        public virtual JobCircular JobCircular { get; set; }
        /*
        public long PersonId { get; set; }
        [Required, ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        */
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public TimeSpan AgeAtLastDateOfSubmission { get; set; }

        //No 18 in form
        [Required]
        public Decision HasContactWithAnyOrganization { get; set; }
        [MinLength(9), MaxLength(600)]
        public string OrganizationContactDescription { get; set; }

        //No 23 in form
        [Required]
        public Decision IsGettingPension { get; set; }
        public UInt64 PensionAmount { get; set; }
        [MinLength(3), MaxLength(50)]
        public string PensionOrganizationName { get; set; }

        public long PaymentId { get; set; }
        [Required, ForeignKey("PersonId")]
        public virtual Payment Payment { get; set; }

        [MinLength(9), MaxLength(1000)]
        public string ExtraInformation { get; set; }            //No 26 in form

        public Decision IsApplicationFinalised { get; set; }
        public Decision IsPaperApplicationReceived { get; set; }
        public SelectionStatus IsSelectedForExam { get; set; }

        public TeacherApplication()
        {
            //AgeAtLastDateOfSubmission =  DateTime.UtcNow - DateOfBirth;
            IsApplicationFinalised = Decision.No;
            IsPaperApplicationReceived = Decision.No;
            IsSelectedForExam = SelectionStatus.Pending;
        }
    }
}
