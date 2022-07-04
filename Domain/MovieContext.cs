using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieAspCore.Domain.Entities;


namespace MovieAspCore.Domain
{
    public class MovieContext : IdentityDbContext<IdentityUser>
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) {}        
        public DbSet<MenuField> MenuFields { get; set; }
        public DbSet<MovieItem> MovieItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "101",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "201",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                //Email = "my@email.com",
                //NormalizedEmail = "MY@EMAIL.COM",
                //EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "ps"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "101",
                UserId = "201"
            });

            modelBuilder.Entity<MenuField>().HasData(new MenuField
            {
                Id = 1,
                CodeWord = "PageIndex",
                Title = "Главная"
            });
            modelBuilder.Entity<MenuField>().HasData(new MenuField
            {
                Id = 2,
                CodeWord = "PageAbout",
                Title = "О сайте"
            });
            modelBuilder.Entity<MenuField>().HasData(new MenuField
            {
                Id = 3,
                CodeWord = "PageLink",
                Title = "Ссылки"
            });
            modelBuilder.Entity<MenuField>().HasData(new MenuField
            {
                Id = 4,
                CodeWord = "PageAddAdmin",
                Title = "Добавить администратора"
            });
        }
    }
}
