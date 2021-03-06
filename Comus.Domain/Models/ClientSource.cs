﻿using Newtonsoft.Json;
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

        public List<Client> Clients { get; set; }
        public List<ClientRequest> ClientRequests { get; set; }
    }
}
