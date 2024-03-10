using FileUpload.Models;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.DAL;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
    {
        
    }


    public DbSet<Service> Services { get; set; } = null!;
}
