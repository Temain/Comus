using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comus.Domain.Models
{
    /// <summary>
    /// Тип продукции
    /// </summary>
    [Table("ProductType", Schema = "dbo")]
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        public List<Product> Products { get; set; }
        public List<Client> Clients { get; set; }
    }
}
