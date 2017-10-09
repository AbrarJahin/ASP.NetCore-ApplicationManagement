using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ApplicationManagement.DbModel.CustomTypes;

namespace ApplicationManagement.DbModel
{
    public class Teacher
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public virtual JobCircular JobCircular { get; set; }
        //No 1 in form
        [Required]
        public string BengaliName { get; set; }
        [Required]
        public string EnglishName { get; set; }
        [Required]
        public string NickName{ get; set; }

        [Required]
        public string FatherName { get; set; }  //No 2 in form
        public string SpouceName { get; set; }  //No 3 in form
        public string MotherName { get; set; }  //No 4 in form

        //No 5 in form
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfbirth { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public TimeSpan AgeAtLastDateOfSubmission { get; set; }

        //No 6 in form
        public long PresentAddressId { get; set; }
        [ForeignKey("PresentAddressId")]
        [Required]
        public virtual Address PresentAddress { get; set; }

        //No 7 in form
        public long PermanentAddressId { get; set; }
        [ForeignKey("PermanentAddressId")]
        [Required]
        public virtual Address PermanentAddress { get; set; }

        [Required]
        public string Nationality { get; set; }         //No 8 in form
        [Required]
        public IsMarried MaritalStatus { get; set; }    //No 9 in form
        [Required]
        public ReligionName Religion { get; set; }      //No 10 in form
        [Required]
        public string NId { get; set; }                 //No 11 in form

        public virtual ICollection<EducationResult> EducationalResults { get; set; }   //No 12 in form

        public virtual ICollection<ResearchDegree> ResearchDegries { get; set; }        //No 13 in form
        public virtual ICollection<Research> Researches { get; set; }                   //No 14 in form
        public virtual ICollection<Language> Languages { get; set; }                    //No 15 in form
        public virtual ICollection<Training> Trainings { get; set; }                    //No 16 in form
        public virtual ICollection<Experience> Experiences { get; set; }                //No 17 in form

        //No 18 in form
        [Required]
        public Decision HasContactWithAnyOrganization { get; set; }
        public string OrganizationContactDescription { get; set; }

        public virtual ICollection<Reference> References { get; set; }                  //No 19 in form

        public string VolunteerExperience { get; set; }                                   //No 20 in form
        public virtual ICollection<Country> VisitedCountries { get; set; }              //No 21 in form

        //No 22 in form
        [Required]
        public Decision IsEverSuspended { get; set; }
        public string SuspensionReason { get; set; }

        //No 23 in form
        [Required]
        public Decision IsGettingPension { get; set; }
        public UInt64 PensionAmount { get; set; }
        public string PensionOrganizationName { get; set; }

        //No 24 in form
        [Required]
        public Decision IsInvolvedWithAnyAssociation { get; set; }
        public string NameOfAssociation { get; set; }
        public string DescriptionOfAssociation { get; set; }

        //No 25 in form
        public PaymentStatus IsPaymentDone { get; set; }
        [Required]
        public string BankDraftOrPayOrderNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfDraftOrOrder { get; set; }
        [Required]
        public UInt16 AmountOfMoney { get; set; }
        [Required]
        public string NameOfBank { get; set; }
        [Required]
        public string BranchOfBank { get; set; }

        public string ExtraInformation { get; set; }            //No 26 in form

        public bool IsApplicationFinalised { get; set; }
        public SelectionStatus IsSelectedForExam { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.S}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }

        public Teacher()
        {
            AddedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;

            AgeAtLastDateOfSubmission =  DateTime.UtcNow - DateOfbirth;
            IsPaymentDone = PaymentStatus.Pending;
        }
    }
}
