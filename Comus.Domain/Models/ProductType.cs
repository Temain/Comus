using Newtonsoft.Json;
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

        /// <summary>
        /// Дата создания записи
        /// </summary>
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Дата обновления записи
        /// </summary>
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Дата удаления записи
        /// </summary>
        [JsonIgnore]
        public DateTime? DeletedAt { get; set; }

        public List<Product> Products { get; set; }
        public List<Client> Clients { get; set; }
        public List<ClientRequest> ClientRequests { get; set; }
    }
}
