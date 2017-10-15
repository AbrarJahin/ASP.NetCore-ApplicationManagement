using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ApplicationManagement.DbModel;
using static ApplicationManagement.DbModel.CustomTypes;
using System.Collections.Generic;
using ApplicationManagement.ViewModel;

namespace ApplicationManagement.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (var context = new ApplicationDbContext())
            {
                context.JobCirculars.Add(new JobCircular
                {
                    Name = "Try Application",
                    Detail = "Anything",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow
                });
                await context.SaveChangesAsync();
            }

            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "You Have Created a New Application";

            using (var context = new ApplicationDbContext())
            {
                Random rnd = new Random();
                UInt16 year = (UInt16)rnd.Next(1999, 2017);

                JobCircular jobCircular = context.JobCirculars
                                            .SingleOrDefault(j => j.Id == 1);
                
                Address presentAddress = new Address
                {
                    HoldingNoOrVillage = "1234",
                    RoadBlockSector = "28",
                    Thana = "Kotawoli",
                    PostOffice = "Rupatoli",
                    District = "Barisal",
                    PhoneNumber = "+8801822804636"
                };
                
                Address permanentAddress = new Address
                {
                    HoldingNoOrVillage = "86/3",
                    RoadBlockSector = "2 No Cross Road",
                    Thana = "Daulatpur",
                    PostOffice = "Daulatpur",
                    District = "Khulna",
                    PhoneNumber = "+8801521251799"
                };

                ICollection<EducationResult> educationalResults = new List<EducationResult>();
                for (int i = 0; i < 4; i++)
                {
                    EducationResult education = new EducationResult
                    {
                        ExamName = "Exam " + i,
                        BoardOrUniversity = "University " + i,
                        GroupOrSubject = "Subject " + i,
                        YearOfPassing = year,
                        YearOfExam = (UInt16)(year + 1),
                        DivisionOrClassOrGPAOrCGPA = i.ToString()
                    };
                    educationalResults.Add(education);
                }

                ICollection<Country> countries = new List<Country>();
                for (int i = 0; i < 4; i++)
                {
                    Country country = new Country
                    {
                        Name = i.ToString()
                    };
                    countries.Add(country);
                }

                ICollection<Experience> experiences = new List<Experience>();
                for (int i = 0; i < 4; i++)
                {
                    Experience experience = new Experience
                    {
                        NameOfPost = i.ToString(),
                        NameOfOrganization = i.ToString(),
                        OrganizationType = OrganizationType.Government,
                        SalaryScale = (UInt16)rnd.Next(1999, 2017),
                        TotalSalary = (UInt16)rnd.Next(1999, 2017),
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow
                    };
                    experiences.Add(experience);
                }

                ICollection<Language> languages = new List<Language>();
                for (int i = 0; i < 4; i++)
                {
                    Language language = new Language
                    {
                        Name = i.ToString(),
                        Skill = i.ToString()
                    };
                    languages.Add(language);
                }

                ICollection<Reference> referances = new List<Reference>();
                for (int i = 0; i < 4; i++)
                {
                    Reference referance = new Reference
                    {
                        Name = i.ToString(),
                        Identity = i.ToString(),
                        Address = i.ToString(),
                        Phone = "01719022029"
                    };
                    referances.Add(referance);
                }

                ICollection<ResearchDegree> researchDegrees = new List<ResearchDegree>();
                for (int i = 0; i < 4; i++)
                {
                    ResearchDegree researchDegree = new ResearchDegree
                    {
                        NameOfDegree = i.ToString(),
                        SubjectOfResearch = i.ToString(),
                        SupervisorsNameAndAddress = i.ToString(),
                        UniversityName = i.ToString(),
                        YearOfPassing = (UInt16)i
                    };
                    researchDegrees.Add(researchDegree);
                }

                ICollection<Research> researches = new List<Research>();
                for (int i = 0; i < 4; i++)
                {
                    Research research = new Research
                    {
                        NameOfPublication = i.ToString(),
                        NameOfPublicationPaper = i.ToString(),
                        NameOfPublicationInstitute = i.ToString(),
                        DateOfPublication = DateTime.UtcNow,
                        EditionOfPublication = i.ToString()
                    };
                    researches.Add(research);
                }

                ICollection<Training> trainings = new List<Training>();
                for (int i = 0; i < 4; i++)
                {
                    Training training = new Training
                    {
                        Name = i.ToString(),
                        Description = i.ToString(),
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow
                    };
                    trainings.Add(training);
                }

                context.TeacherApplications.Add(new DbModel.TeacherApplication
                {
                    JobCircular = jobCircular,
                    BengaliName = "আবরার",
                    EnglishName = "Abrar",
                    NickName = "জাহিন",

                    FatherName = "Joynal Abedin",
                    MotherName = "Jinatun Nissaa",
                    SpouceName = "N/A",

                    DateOfBirth = DateTime.ParseExact("31/12/1992", "dd/MM/yyyy", CultureInfo.InvariantCulture),

                    PresentAddress = presentAddress,
                    PermanentAddress = permanentAddress,

                    Nationality = "Bangladeshi",
                    MaritalStatus = IsMarried.Unmarried,
                    Religion = ReligionName.Islam,
                    NId = 19924792106000500+(UInt64)rnd.Next(100000000, 2147483647),

                    EducationalResults = educationalResults,
                    ResearchDegries = researchDegrees,
                    Researches = researches,
                    Trainings = trainings,
                    Experiences = experiences,
                    Languages = languages,
                    HasContactWithAnyOrganization = Decision.No,
                    References = referances,
                    VisitedCountries = countries,
                    IsEverSuspended = Decision.No,
                    IsGettingPension = Decision.No,
                    IsInvolvedWithAnyAssociation = Decision.No,

                    BankDraftOrPayOrderNo = rnd.Next(100000000, 2147483647).ToString(),
                    DateOfDraftOrOrder = DateTime.UtcNow,
                    AmountOfMoney = (UInt16)rnd.Next(100, 9999),
                    NameOfBank = rnd.Next(100000000, 2147483647).ToString(),
                    BranchOfBank = rnd.Next(100000000, 2147483647).ToString(),
                });

                //jobCircular.Teachers.Add();
                await context.SaveChangesAsync();
            }
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Please enter data";

            return View();
        }

        [HttpPost]
        public IActionResult ContactPost(ViewModel.TeacherApplication teacherApplication)
        {
            ViewData["Message"] = teacherApplication.BengaliName;

            return View("~/Views/Home/Contact.cshtml");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
