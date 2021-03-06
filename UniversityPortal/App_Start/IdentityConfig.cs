﻿using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;

namespace UniversityPortal.Models
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                //RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole,string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext> 
    {
        protected override void Seed(ApplicationDbContext context) {
            InitializeIdentityForEF(context);
            SeedData(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db) {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "2010-UET-GDCB-LHR-100";
            const string username = "Administrator";
            const string useremail = "Administrator@gmail.com";
            const string password = "Admin@123456";
            string[] roles =new []{ "Admin","Student","Teacher"};

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roles[0]);
            if (role == null)
            {
                foreach (var r in roles)
                {
                    role = new IdentityRole(r);
                    var roleresult = roleManager.Create(role); 
                }
            }

            role = new IdentityRole(roles[0]);

            var user = userManager.FindByName(name);
            if (user == null) {
                user = new ApplicationUser { UserName = name, Email = useremail, FirstName = username };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name)) {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }

        public static void SeedData(ApplicationDbContext context)
        {
            //Semester
            context.Semesters.Add(new Semester() { Semestername = "Fall 2013" });
            context.Semesters.Add(new Semester() { Semestername = "summer 2013" });
            context.Semesters.Add(new Semester() { Semestername = "Spring 2013" });
            context.Semesters.Add(new Semester() { Semestername = "Fall 2014" });
            context.Semesters.Add(new Semester() { Semestername = "Summer 2014" });
            context.Semesters.Add(new Semester() { Semestername = "spring 2014" });
            context.Semesters.Add(new Semester() { Semestername = "Fall 2015" });
            context.Semesters.Add(new Semester() { Semestername = "Summer 2015" });



            //Designation
            context.Designations.Add(new Designation() { DesignationName = "Professor" });
            context.Designations.Add(new Designation() { DesignationName = "asst. Professor" });
            context.Designations.Add(new Designation() { DesignationName = "Lecturer" });
            context.Designations.Add(new Designation() { DesignationName = "Asst Lecturer" });

            //Department
            context.Departments.Add(new Department() { Code = "CSE", Name = "Computer Science" });


            //room
            context.Rooms.Add(new Room() { Name = "A 501" });
            context.Rooms.Add(new Room() { Name = "A 502" });
            context.Rooms.Add(new Room() { Name = "A 505" });
            context.Rooms.Add(new Room() { Name = "B 601" });
            context.Rooms.Add(new Room() { Name = "B 609" });
            context.Rooms.Add(new Room() { Name = "MCL A" });


            //Day

            context.Days.Add(new Day() { Name = "SaturDay" });
            context.Days.Add(new Day() { Name = "SunDay" });
            context.Days.Add(new Day() { Name = "MonDay" });
            context.Days.Add(new Day() { Name = "TuesDay" });
            context.Days.Add(new Day() { Name = "WednesDay" });
            context.Days.Add(new Day() { Name = "ThursDay" });
            context.Days.Add(new Day() { Name = "Friday" });

            //grade
            context.Grades.Add(new Grade() { Name = "A+" });
            context.Grades.Add(new Grade() { Name = "A" });
            context.Grades.Add(new Grade() { Name = "B+" });
            context.Grades.Add(new Grade() { Name = "B" });
            context.Grades.Add(new Grade() { Name = "C+" });
            context.Grades.Add(new Grade() { Name = "C" });
            context.Grades.Add(new Grade() { Name = "D" });
            context.Grades.Add(new Grade() { Name = "F" });

            context.SaveChanges();
        }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) : 
            base(userManager, authenticationManager) { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}