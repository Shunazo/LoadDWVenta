using Microsoft.EntityFrameworkCore;
using LoadDWVenta.Data.Entities.DWHNorthwindOrders;

namespace LoadDWVenta.Data.Context
{
    public class DWHContext : DbContext
    {
        public DWHContext(DbContextOptions<DWHContext> options) : base(options)
        { }

        #region"Db Sets
        public DbSet<DimEmployee> DimEmployee { get; set; }
        public DbSet<DimCategory> DimCategory { get; set; }
        public DbSet<DimProduct> DimProduct { get; set; }
        public DbSet<DimSupplier> DimSupplier { get; set; }
        #endregion
    }

}
