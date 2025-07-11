using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var masterUser = new User
            {
                Id = 1,
                EmpNo = "admin",
                Role = "Admin",
                //PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234")
                PasswordHash = "$2a$11$Eo1mDyYGnRhUw2fd9UXnXeNk2UdchmdZ1ihX5jIPAd5GJ3P43LnwC"
            };

            modelBuilder.Entity<User>().HasData(masterUser);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", schema: "admin"); // 실제 테이블 이름과 일치 (소문자)
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.EmpNo).IsUnique();

                entity.Property(e => e.EmpNo).HasColumnName("emp_no").HasMaxLength(20).IsRequired();
                entity.Property(e => e.Role).HasColumnName("role").HasMaxLength(30).IsRequired();
                entity.Property(e => e.PasswordHash).HasColumnName("password_hash").HasMaxLength(255).IsRequired();
            });
        }
    }

}
