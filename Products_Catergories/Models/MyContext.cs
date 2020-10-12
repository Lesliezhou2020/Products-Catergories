using Microsoft.EntityFrameworkCore;
namespace Products_Catergories.Models
{ 
    // the MyContext class representing a session with our MySQL 
    // database allowing us to query for or save data
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        // the "Monsters" table name will come from the DbSet variable name
        public DbSet<Product> Products { get; set; }
        public DbSet<Catergory> Catergories {get; set;}
        public DbSet<Association> Associations {get; set;}
    }
}