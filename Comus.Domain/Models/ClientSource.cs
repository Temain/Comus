using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comus.Domain.Models
{
    /// <summary>
    /// Источник привлечения клиента
    /// </summary>
    [Table("ClientSource", Schema = "dbo")]
    public class ClientSource
    {
        public int ClientSourceId { get; set; }
        public string ClientSourceName { get; set; }

        public List<Client> Clients { get; set; }
    }
}
