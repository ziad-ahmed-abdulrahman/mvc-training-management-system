using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace TrainingManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

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


        }

    }
}
