using Microsoft.EntityFrameworkCore;
using LoadDWVenta.Data.Entities.Northwind;

namespace LoadDWVenta.Data.Context
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) 
        { }


        #region"Db Sets"
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Product> Products { get; set; }

      

        #endregion

    }


}
