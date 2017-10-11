using System;
using System.ComponentModel.DataAnnotations;
using static ApplicationManagement.DbModel.CustomTypes;

namespace ApplicationManagement.ViewModel
{
    public class TeacherApplication
    {
        public long JobCircularId { get; set; }

        //No 1 in form
        [Required, MinLength(3), MaxLength(60)]
        [Display(Name = "Bengali Name")]
        public string BengaliName { get; set; }
        [Required, MinLength(3), MaxLength(60)]
        [Display(Name = "English Name")]
        public string EnglishName { get; set; }
        [Required, MinLength(3), MaxLength(60)]
        [Display(Name = "Nick Name")]
        public string NickName { get; set; }

        [Required, MinLength(3), MaxLength(60)]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }  //No 2 in form
        [MinLength(3), MaxLength(60)]
        [Display(Name = "Spouce Name")]
        public string SpouceName { get; set; }  //No 3 in form
        [MinLength(3), MaxLength(60)]
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }  //No 4 in form

        //No 5 in form
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required, MinLength(4), MaxLength(20)]
        public string Nationality { get; set; }         //No 8 in form
        [Required]
        [Display(Name = "Marital Status")]
        public IsMarried MaritalStatus { get; set; }    //No 9 in form
        [Required]
        public ReligionName Religion { get; set; }      //No 10 in form
        //[Required, MinLength(17), MaxLength(17)]
        [Range(1000000000, 99999999999999999)]
        [Display(Name = "National ID Card No.")]
        public UInt64 NId { get; set; }                 //No 11 in form

        //No 18 in form
        [Required]
        [Display(Name = "Has Contact With Any Organization")]
        public Decision HasContactWithAnyOrganization { get; set; }
        [MinLength(20), MaxLength(1000)]
        [Display(Name = "Organization Contact Description")]
        public string OrganizationContactDescription { get; set; }
        [MinLength(20), MaxLength(600)]
        [Display(Name = "Volunteer Experience")]
        public string VolunteerExperience { get; set; }                                   //No 20 in form
 
        //No 22 in form
        [Required]
        [Display(Name = "Is Ever Suspended")]
        public Decision IsEverSuspended { get; set; }
        [MinLength(40), MaxLength(600)]
        [Display(Name = "Suspension Reason")]
        public string SuspensionReason { get; set; }

        //No 23 in form
        [Required]
        [Display(Name = "Is Getting Pension")]
        public Decision IsGettingPension { get; set; }
        [Display(Name = "Pension Amount")]
        public UInt64 PensionAmount { get; set; }
        [MinLength(2), MaxLength(100)]
        [Display(Name = "Pension Giving Organization Name")]
        public string PensionOrganizationName { get; set; }

        //No 24 in form
        [Required]
        public Decision IsInvolvedWithAnyAssociation { get; set; }
        [MinLength(4), MaxLength(80)]
        [Display(Name = "Name Of Association")]
        public string NameOfAssociation { get; set; }
        [MinLength(20), MaxLength(600)]
        [Display(Name = "Description Of Association")]
        public string DescriptionOfAssociation { get; set; }

        //No 25 in form
        [MinLength(10), MaxLength(100)]
        [Display(Name = "Bank Draft Or Pay Order No")]
        public string BankDraftOrPayOrderNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Date Of Draft Or Order")]
        public DateTime DateOfDraftOrOrder { get; set; }
        [Required]
        [Display(Name = "Amount Of Money")]
        public UInt16 AmountOfMoney { get; set; }
        [Required, MinLength(2), MaxLength(100)]
        [Display(Name = "Name Of Bank")]
        public string NameOfBank { get; set; }
        [Required, MinLength(2), MaxLength(100)]
        [Display(Name = "Branch Of Bank")]
        public string BranchOfBank { get; set; }

        [MinLength(10), MaxLength(700)]
        [Display(Name = "Extra Information")]
        public string ExtraInformation { get; set; }
    }
}
