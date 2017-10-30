using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ApplicationManagement.DbModel.CustomTypes;

namespace ApplicationManagement.DbModel
{
    public class Person : BaseEntity
    {
        //No 0 in form
        [Required, MinLength(3), MaxLength(200)]
        public string ProfileImageFileUrl { get; set; }

        //No 1 in form
        [Required, MinLength(3), MaxLength(50)]
        public string BengaliName { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string EnglishName { get; set; }
        [Required, MinLength(3), MaxLength(20)]
        public string NickName { get; set; }

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
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DateOfBirth { get; set; }

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

        public virtual ICollection<Reference> References { get; set; }                  //No 19 in form

        [MinLength(9), MaxLength(600)]
        public string VolunteerExperience { get; set; }                                 //No 20 in form
        public virtual ICollection<Country> VisitedCountries { get; set; }              //No 21 in form

        //No 24 in form
        [Required]
        public Decision IsInvolvedWithAnyAssociation { get; set; }
        [MinLength(3), MaxLength(50)]
        public string NameOfAssociation { get; set; }
        [MinLength(9), MaxLength(600)]
        public string DescriptionOfAssociation { get; set; }

        //No 22 in form
        [Required]
        public Decision IsEverSuspended { get; set; }
        [MinLength(9), MaxLength(600)]
        public string SuspensionReason { get; set; }

        public virtual ICollection<TeacherApplication> TeacherApplications { get; set; }

        public virtual ICollection<CountryPerson> CountryPersons { get; set; }
    }
}
