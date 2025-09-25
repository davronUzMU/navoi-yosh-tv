using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using onlatn_tv_project.Models;

namespace onlatn_tv_project.Data
{
    public class AppDbContext :IdentityDbContext<IdentityUser>
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
          : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<TVProgram> tVPrograms { get; set; }
        public DbSet<ShowsTV> showsTVs { get; set; }
        public DbSet<ShowsBackTV> showsBackTVs { get; set; }
        public DbSet<BlockTV> blockTVs { get; set; }
        public DbSet<BlockBlackTV> blockBackTVs { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<NewsTV> newsTVs { get; set; }
        public DbSet<NewsBackTV> newsBackTVs { get; set; }
        public DbSet<User> users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
