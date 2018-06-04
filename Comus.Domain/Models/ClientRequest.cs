using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Comus.Domain.Models
{
    /// <summary>
    /// Заявка
    /// </summary>
    [Table("ClientRequest", Schema = "dbo")]
    public class ClientRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ClientRequestId { get; set; }

        /// <summary>
        /// Компания
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Физическое лицо
        /// </summary>
        public int PersonId { get; set; }
        public Person Person { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Источник привлечения
        /// </summary>
        public int? ClientSourceId { get; set; }
        public ClientSource ClientSource { get; set; }

        /// <summary>
        /// Тип продукции
        /// </summary>
        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Статус заявки
        /// </summary>
        public int? ClientRequestStatusId { get; set; }
        public ClientRequestStatus ClientRequestStatus { get; set; }

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
    }

}
