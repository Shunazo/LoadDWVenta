using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWVenta.Data.Entities.DWHNorthwindOrders
{
    [Table("DimCategory")]
    public class DimCategory
    {
       [Key] public int CategoryID { get; set; }
        public string? CategoryName { get; set; }

        public string? Description { get; set;}

    }
}
