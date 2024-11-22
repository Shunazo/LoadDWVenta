using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWVenta.Data.Entities.DWHNorthwindOrders
{
    [Table("DimEployee")]
    public class DimEmployee
    {
        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

    }

  }

