using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace ApplicationManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {

                // Migrate the database
                context.Database.EnsureCreated();
                //... the remaining code

                // Add a video game with its release year filled
                context.Person.Add(new DbModel.Person
                {
                    Name = "A",
                    DateOfbirth = DateTime.Now
                });
                context.SaveChanges();

            }

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
