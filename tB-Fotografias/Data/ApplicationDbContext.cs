using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tB_Fotografias.Models;

namespace tB_Fotografias.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<MyUser> MyUsers { get; set; }
        public DbSet<Purchase> Purchases { get; set; } 
        public DbSet<Photography> Photographies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
