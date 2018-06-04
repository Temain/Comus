using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Comus.Domain.Models
{
    /// <summary>
    /// Ствтус заявки
    /// </summary>
    [Table("ClientRequestStatus", Schema = "dbo")]
    public class ClientRequestStatus
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ClientRequestStatusId { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string ClientRequestStatusName { get; set; }

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

        public List<ClientRequest> ClientRequests { get; set; }
    }

}
