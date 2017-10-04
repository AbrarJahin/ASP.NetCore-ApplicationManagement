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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public UInt64 Id { get; set; }
        [ForeignKey("JobCircular")]
        public UInt64 JobCircularId { get; set; }

        //No 1 in form
        public string BengaliName { get; set; }
        public string EnglishName { get; set; }
        public string NickName{ get; set; }

        public string FatherName { get; set; }  //No 2 in form
        public string SpouceName { get; set; }  //No 3 in form
        public string MotherName { get; set; }  //No 4 in form

        //No 5 in form
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateOfbirth { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public TimeSpan AgeAtLastDateOfSubmission { get; set; }

        public Address PresentAddress { get; set; }     //No 6 in form
        public Address PermanentAddress { get; set; }   //No 7 in form

        public string Nationality { get; set; }         //No 8 in form

        public IsMarried MaritalStatus { get; set; }    //No 9 in form
        public ReligionName Religion { get; set; }      //No 10 in form
        public string NId { get; set; }                 //No 11 in form

        public ICollection<EducationalStatus> EducationalResult { get; set; }   //No 12 in form

        public ICollection<ResearchDegree> ResearchDegries { get; set; }        //No 13 in form
        public ICollection<Research> Researches { get; set; }                   //No 14 in form
        public ICollection<Language> Languages { get; set; }                    //No 15 in form
        public ICollection<Training> Trainings { get; set; }                    //No 16 in form
        public ICollection<Experience> Experiences { get; set; }                //No 17 in form

        //No 18 in form
        public Decision HasContactWithAnyOrganization { get; set; }
        public string OrganizationContactDescription { get; set; }

        public ICollection<Reference> References { get; set; }                  //No 19 in form

        public string VolunteerExperience { get; set; }                         //No 20 in form
        public ICollection<Country> VisitedCountries { get; set; }              //No 21 in form

        //No 22 in form
        public Decision IsEverSuspended { get; set; }
        public string SuspensionReason { get; set; }

        //No 23 in form
        public Decision IsGettingPension { get; set; }
        public UInt64 PensionAmount { get; set; }
        public string PensionOrganizationName { get; set; }

        //No 24 in form
        public Decision IsInvolvedWithAnyAssociation { get; set; }
        public string NameOfAssociation { get; set; }
        public string DescriptionOfAssociation { get; set; }

        //No 25 in form
        public PaymentStatus IsPaymentDone { get; set; }
        public string BankDraftOrPayOrderNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateOfDraftOrOrder { get; set; }
        public UInt16 AmountOfMoney { get; set; }
        public string NameOfBank { get; set; }
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
            AddedDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;

            AgeAtLastDateOfSubmission = DateTime.Now - DateOfbirth;
        }
    }
}
