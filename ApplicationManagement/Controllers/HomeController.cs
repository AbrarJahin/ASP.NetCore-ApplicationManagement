using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ApplicationManagement.DbModel;
using static ApplicationManagement.DbModel.CustomTypes;

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
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                    Detail = "Anything"
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

                var jobCircular1 = context.JobCirculars;

                JobCircular jobCircular = context.JobCirculars
                                            .SingleOrDefault(j => j.Id == 1);

                /*
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
                */
                context.Teachers.Add(new Teacher
                {
                    JobCircular = jobCircular,
                    BengaliName = "আবরার",
                    EnglishName = "Abrar",
                    NickName = "জাহিন",

                    FatherName = "Joynal Abedin",
                    MotherName = "Jinatun Nissaa",
                    SpouceName = "N/A",

                    DateOfbirth = DateTime.ParseExact("31/12/1992", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    AgeAtLastDateOfSubmission = DateTime.UtcNow - DateTime.ParseExact("31/12/1992", "dd/MM/yyyy", CultureInfo.InvariantCulture),

                    //PresentAddress = presentAddress,
                    //PermanentAddress = permanentAddress,

                    Nationality = "Bangladeshi",
                    MaritalStatus = IsMarried.Unmarried,
                    Religion = ReligionName.Islam,
                    NId = rnd.Next(100000000, 2147483647).ToString(),

                    //EducationalResults = educationalResults
                });

                //jobCircular.Teachers.Add();
                await context.SaveChangesAsync();
            }
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
