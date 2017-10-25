using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ApplicationManagement.DbModel.CustomTypes;

namespace ApplicationManagement.DbModel
{
    public class TeacherApplication
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public virtual JobCircular JobCircular { get; set; }

        //No 0 in form
        [Required, MinLength(3), MaxLength(200)]
        public string ProfileImageFileUrl { get; set; }

        //No 1 in form
        [Required, MinLength(3), MaxLength(50)]
        public string BengaliName { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string EnglishName { get; set; }
        [Required, MinLength(3), MaxLength(20)]
        public string NickName{ get; set; }

        [Required, Phone, MinLength(9), MaxLength(16)]
        public string PhoneNumber { get; set; }
        [Required, EmailAddress, MinLength(4), MaxLength(50)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Check email address format!")]
        public string Email { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string FatherName { get; set; }  //No 2 in form
        [MinLength(3), MaxLength(50)]
        public string SpouceName { get; set; }  //No 3 in form
        [MinLength(3), MaxLength(50)]
        public string MotherName { get; set; }  //No 4 in form

        //No 5 in form
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public TimeSpan AgeAtLastDateOfSubmission { get; set; }

        //No 6 in form
        public long PresentAddressId { get; set; }
        [Required, ForeignKey("PresentAddressId")]
        public virtual Address PresentAddress { get; set; }

        //No 7 in form
        public long PermanentAddressId { get; set; }
        [Required, ForeignKey("PermanentAddressId")]
        public virtual Address PermanentAddress { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string Nationality { get; set; }         //No 8 in form
        [Required]
        public IsMarried MaritalStatus { get; set; }    //No 9 in form
        [Required]
        public ReligionName Religion { get; set; }      //No 10 in form
        [Required, Range(1000000000, 99999999999999999)]
        public UInt64 NId { get; set; }                 //No 11 in form

        public virtual ICollection<EducationResult> EducationalResults { get; set; }   //No 12 in form

        public virtual ICollection<ResearchDegree> ResearchDegries { get; set; }        //No 13 in form
        public virtual ICollection<Research> Researches { get; set; }                   //No 14 in form
        public virtual ICollection<Language> Languages { get; set; }                    //No 15 in form
        public virtual ICollection<Training> Trainings { get; set; }                    //No 16 in form
        public virtual ICollection<Experience> Experiences { get; set; }                //No 17 in form

        //No 18 in form
        [Required]
        public Decision HasContactWithAnyOrganization { get; set; }
        [MinLength(9), MaxLength(600)]
        public string OrganizationContactDescription { get; set; }

        public virtual ICollection<Reference> References { get; set; }                  //No 19 in form

        [MinLength(9), MaxLength(600)]
        public string VolunteerExperience { get; set; }                                   //No 20 in form
        public virtual ICollection<Country> VisitedCountries { get; set; }              //No 21 in form

        //No 22 in form
        [Required]
        public Decision IsEverSuspended { get; set; }
        [MinLength(9), MaxLength(600)]
        public string SuspensionReason { get; set; }

        //No 23 in form
        [Required]
        public Decision IsGettingPension { get; set; }
        public UInt64 PensionAmount { get; set; }
        [MinLength(3), MaxLength(50)]
        public string PensionOrganizationName { get; set; }

        //No 24 in form
        [Required]
        public Decision IsInvolvedWithAnyAssociation { get; set; }
        [MinLength(3), MaxLength(50)]
        public string NameOfAssociation { get; set; }
        [MinLength(9), MaxLength(600)]
        public string DescriptionOfAssociation { get; set; }

        //No 25 in form
        public PaymentStatus IsPaymentDone { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string BankDraftOrPayOrderNo { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfDraftOrOrder { get; set; }
        [Required]
        public UInt16 AmountOfMoney { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string NameOfBank { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string BranchOfBank { get; set; }
        [MinLength(9), MaxLength(1000)]
        public string ExtraInformation { get; set; }            //No 26 in form

        public bool IsApplicationFinalised { get; set; }
        public Decision IsPaperApplicationReceived { get; set; }
        public SelectionStatus IsSelectedForExam { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime LastModifiedDate { get; set; }

        public TeacherApplication()
        {
            AddedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
            //AgeAtLastDateOfSubmission =  DateTime.UtcNow - DateOfBirth;
            IsPaymentDone = PaymentStatus.Pending;
            IsApplicationFinalised = false;
            IsPaperApplicationReceived = Decision.No;
            IsSelectedForExam = SelectionStatus.Pending;
        }
    }
}
