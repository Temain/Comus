using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comus.Domain.Models
{
    /// <summary>
    /// Статус клиента
    /// </summary>
    [Table("ClientStatus", Schema = "dbo")]
    public class ClientStatus
    {
        public int ClientStatusId { get; set; }
        public string ClientStatusName { get; set; }

        public List<Client> Clients { get; set; }
    }
}
