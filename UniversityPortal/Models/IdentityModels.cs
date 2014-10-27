using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace UniversityPortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public System.DateTime? DateOfBirth { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        //#region Tables Creation

        //public virtual DbSet<ArchivedEmployee> ArchivedEmployees { get; set; }
        //public virtual DbSet<ArchivedStudent> ArchivedStudents { get; set; }
        //public virtual DbSet<AssessmentScore> AssessmentScores { get; set; }
        //public virtual DbSet<Attendence> Attendences { get; set; }
        //public virtual DbSet<Batch> Batches { get; set; }
        //public virtual DbSet<CceExamCategory> CceExamCategories { get; set; }
        //public virtual DbSet<CceGrade> CceGrades { get; set; }
        //public virtual DbSet<CceGradeSet> CceGradeSets { get; set; }
        //public virtual DbSet<CceReport> CceReports { get; set; }
        //public virtual DbSet<CceWeightage> CceWeightages { get; set; }
        //public virtual DbSet<CceWeightagesCourse> CceWeightagesCourses { get; set; }
        //public virtual DbSet<ClassDesignation> ClassDesignations { get; set; }
        //public virtual DbSet<ClassTiming> ClassTimings { get; set; }
        //public virtual DbSet<Course> Courses { get; set; }
        //public virtual DbSet<Employee> Employees { get; set; }
        //public virtual DbSet<EmployeeAdditionalDetail> EmployeeAdditionalDetails { get; set; }
        //public virtual DbSet<EmployeeAdditionalField> EmployeeAdditionalFields { get; set; }
        //public virtual DbSet<EmployeeAttendence> EmployeeAttendences { get; set; }
        //public virtual DbSet<EmployeeCategory> EmployeeCategories { get; set; }
        //public virtual DbSet<EmployeeCours> EmployeeCourses { get; set; }
        //public virtual DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        //public virtual DbSet<EmployeeDepartmentEvent> EmployeeDepartmentEvents { get; set; }
        //public virtual DbSet<EmployeeLeave> EmployeeLeaves { get; set; }
        //public virtual DbSet<EmployeeLeaveType> EmployeeLeaveTypes { get; set; }
        //public virtual DbSet<EmployeePreviousData> EmployeePreviousDatas { get; set; }
        //public virtual DbSet<EmployeeResearch> EmployeeResearches { get; set; }
        //public virtual DbSet<EmployeesSubject> EmployeesSubjects { get; set; }
        //public virtual DbSet<Event> Events { get; set; }
        //public virtual DbSet<Exam> Exams { get; set; }
        //public virtual DbSet<ExamGroup> ExamGroups { get; set; }
        //public virtual DbSet<ExamScore> ExamScores { get; set; }
        //public virtual DbSet<FaCriteria> FaCriterias { get; set; }
        //public virtual DbSet<FaGroup> FaGroups { get; set; }
        //public virtual DbSet<FaGroupsSubject> FaGroupsSubjects { get; set; }
        //public virtual DbSet<Gardian> Gardians { get; set; }
        //public virtual DbSet<GradingLevel> GradingLevels { get; set; }
        //public virtual DbSet<Job> Job { get; set; }
        //public virtual DbSet<News> News { get; set; }
        //public virtual DbSet<NewsComment> NewsComments { get; set; }
        //public virtual DbSet<Observation> Observations { get; set; }
        //public virtual DbSet<ObservationGroup> ObservationGroups { get; set; }
        //public virtual DbSet<RankingLevel> RankingLevels { get; set; }
        //public virtual DbSet<StudentAdditionalDetail> StudentAdditionalDetails { get; set; }
        //public virtual DbSet<StudentAdditionalField> StudentAdditionalFields { get; set; }
        //public virtual DbSet<StudentCategory> StudentCategories { get; set; }
        //public virtual DbSet<StudentPreviousData> StudentPreviousDatas { get; set; }
        //public virtual DbSet<StudentPreviousSubjectMark> StudentPreviousSubjectMarks { get; set; }
        //public virtual DbSet<Student> Students { get; set; }
        //public virtual DbSet<StudentSubject> StudentSubjects { get; set; }
        //public virtual DbSet<SubjectLeave> SubjectLeaves { get; set; }
        //public virtual DbSet<Subject> Subjects { get; set; }
        //public virtual DbSet<Testimonial> Testimonial { get; set; }
        //public virtual DbSet<Timetable> Timetables { get; set; }
        //public virtual DbSet<TimetableEntry> TimetableEntries { get; set; }
        //public virtual DbSet<Week_Day> Week_Day { get; set; }

        //#endregion

        #region New Table

        public virtual DbSet<Basic> Basic { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Testimonial> Testimonial { get; set; }

        //New Database

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<AssignCourse> AssignCourses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAllocation> RoomAllocations { get; set; }
        public DbSet<Day> Days { get; set; }

        public DbSet<EnrollCourse> EnrollCourses { get; set; }
        public DbSet<ResultEntry> ResultEntries { get; set; }
        public DbSet<Grade> Grades { set; get; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Rename identity tables

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("User");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRole");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogin");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaim");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");

            #endregion
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}