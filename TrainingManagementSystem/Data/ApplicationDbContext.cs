using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TrainingManagementSystem.Models;


namespace TrainingManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsReslt> CrsReslts { get; set; }
        public DbSet<Trainee> Trainees { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>(d =>
            {
                d.HasKey(d => d.Id);
                d.Property(d => d.Id).ValueGeneratedOnAdd().UseIdentityColumn(seed: 1, increment: 1);
                d.Property(d => d.Name).IsRequired();
                d.Property(d => d.ManagerName).IsRequired();




            });

            modelBuilder.Entity<Instructor>(i =>
            {
                i.HasKey(i => i.Id);
                i.Property(i => i.Id).ValueGeneratedOnAdd().UseIdentityColumn(seed: 1, increment: 1);
                i.Property(i => i.Name).IsRequired();
                i.Property(i => i.Salary).IsRequired();
                i.Property(i => i.Address).IsRequired(false);

                i.HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DeptId)
                .OnDelete(DeleteBehavior.NoAction);


                i.HasOne(i => i.Course)
                .WithMany(c => c.Instructors)
                .HasForeignKey(i => i.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Course>(c =>
            {
                c.HasKey(c => c.Id);
                c.Property(c => c.Id).ValueGeneratedOnAdd().UseIdentityColumn(seed: 1, increment: 1);
                c.Property(c => c.Name).IsRequired();
                c.Property(c => c.Degree).IsRequired();
                c.Property(c => c.MinDegree).IsRequired();

                c.HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DeptId)
                .OnDelete(DeleteBehavior.NoAction);

                c.HasMany(c => c.CrsReslts)
                .WithOne(Cr => Cr.Course)
                .HasForeignKey(c => c.CrsId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Trainee>(t =>
            {
                t.HasKey(t => t.Id);
                t.Property(t => t.Id).ValueGeneratedOnAdd().UseIdentityColumn(seed: 1, increment: 1);
                t.Property(t => t.Name).IsRequired();
                t.Property(t => t.Address).IsRequired(false);
                t.Property(t => t.Grade).IsRequired();

                t.HasOne(i => i.Department)
                .WithMany(d => d.Trainees)
                .HasForeignKey(i => i.DeptId)
                .OnDelete(DeleteBehavior.NoAction);

                t.HasMany(t => t.CrsReslts)
                .WithOne(Cr => Cr.Trainee)
                .HasForeignKey(i => i.TraineeId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CrsReslt>(Cr =>
            {
                Cr.HasKey(Cr => new { Cr.TraineeId, Cr.CrsId });
                Cr.Property(Cr => Cr.Id).IsRequired();
                Cr.Property(Cr => Cr.Degree).IsRequired(false);
                Cr.Property(Cr => Cr.IsPassed).IsRequired(false);
                Cr.Property(Cr => Cr.DateCompleted).IsRequired(false);


            }
                );

            // ===================== Seed Data =====================

            // Users

            var adminSettings = _configuration.GetSection("AdminUserData");

            string roleId = "B74DDD14-6340-4840-95C2-DB12554843E5";
            string userId = "A12DDD14-6340-4840-95C2-DB12554843E1";
            string email = adminSettings["Email"] ?? "admin@ziad.com";
            string userName = adminSettings["UserName"] ?? "AdminZiad";
            string password = adminSettings["Password"] ?? "DefaultPass123!";

            // Hash the password dynamically
            var passwordHasher = new PasswordHasher<Users>();
            var tempUser = new Users { Id = userId, UserName = userName, Email = email };
            string hashedPassword = passwordHasher.HashPassword(tempUser, password);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = userId,
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hashedPassword
            });

            // Bind Role to User
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });
            // Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Computer Science", ManagerName = "Alice" },
                new Department { Id = 2, Name = "Mathematics", ManagerName = "Bob" }
            );

            // Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "C# Basics", Degree = 100, MinDegree = 50, DeptId = 1 },
                new Course { Id = 2, Name = "Advanced Math", Degree = 100, MinDegree = 60, DeptId = 2 }
            );

            // Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, Name = "John Doe", Salary = 5000, Address = "123 Main St", DeptId = 1, CourseId = 1 },
                new Instructor { Id = 2, Name = "Jane Smith", Salary = 5500, Address = "456 Side Rd", DeptId = 2, CourseId = 2 }
            );

            // Trainees
            modelBuilder.Entity<Trainee>().HasData(
                new Trainee { Id = 1, Name = "Ahmed Ali", Grade = 90, Address = "Cairo", DeptId = 1 },
                new Trainee { Id = 2, Name = "Sara Mohamed", Grade = 85, Address = "Alex", DeptId = 2 }
            );

            // CrsReslt (Composite Key)
            modelBuilder.Entity<CrsReslt>().HasData(
                new CrsReslt { CrsId = 1, TraineeId = 1, Id = 1, Degree = 90, IsPassed = true, DateCompleted = new DateTime(2026, 3, 12) },
                new CrsReslt { CrsId = 2, TraineeId = 2, Id = 2, Degree = 85, IsPassed = true, DateCompleted = new DateTime(2026, 3, 12) }
            );


        }

    }
}
