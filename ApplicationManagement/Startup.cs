using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using WebMarkupMin.AspNetCore1;

namespace ApplicationManagement
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        private ILogger _logger;

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Startup>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            using (var context = new ApplicationDbContext())
            {
                if (env.IsDevelopment())
                {
                    context.Database.EnsureDeleted();
                }
                // Migrate the database
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add Configuration Service
            services.AddSingleton<IConfiguration>(Configuration);

            /*
            //Configure DB Connection String
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DbContextSettings:ConnectionString")));
            */

            // Add framework services.
            services.AddMvc();

            // Add EntityFramework Service.
            services.AddEntityFrameworkSqlite().AddDbContext<ApplicationDbContext>();

            //HTML minifire service
            //With This - using WebMarkupMin.AspNetCore1;
            services.AddWebMarkupMin(
                options =>
                {
                    options.AllowMinificationInDevelopmentEnvironment = false;
                    options.AllowCompressionInDevelopmentEnvironment = false;
                })
                .AddHtmlMinification(
                    options =>
                    {
                        options.MinificationSettings.RemoveRedundantAttributes = true;
                        options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                        options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;

                        options.MinificationSettings.RemoveEmptyAttributes = true;
                        options.MinificationSettings.RemoveHtmlComments = true;
                        options.MinificationSettings.RemoveOptionalEndTags = true;
                    })
                .AddHttpCompression();
            /*
            //Configure Identity
            services.AddIdentity<Users, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext, Guid>()
                .AddDefaultTokenProviders();
            */

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // Cookie settings
                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
                options.Cookies.ApplicationCookie.LoginPath = "/Account/LogIn";
                options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOut";

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            // Add Configuration Manager services.
            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ApplicationDbContext applicationDbContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //Seed The Database
            try
            {
                applicationDbContext.Seed(app);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            app.UseStaticFiles();
            /*
            //Configure Identity
            app.UseIdentity();
            */

            //HTML Minifire With This - using WebMarkupMin.AspNetCore1;
            app.UseWebMarkupMin();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
