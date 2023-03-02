using DbAccessLib.Models;
using Microsoft.EntityFrameworkCore;

namespace DbAccessLib.DataAccess;

public class DatabaseDbContext : DbContext
{
    public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options) 
        : base(options)
    {
        
    }
    public DbSet<TestModel> TestModels { get; set; }
    public DbSet<TestModelPlus> TestModelPluss { get; set; }
   
    
}