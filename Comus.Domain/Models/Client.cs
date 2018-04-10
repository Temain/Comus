using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Comus.Domain.Models
{
    /// <summary>
    /// Клиент
    /// </summary>
    [Table("Client", Schema = "dbo")]
    public class Client
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Компания
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Размер персональной скидки
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// Средний объем закупок
        /// </summary>
        public decimal? VolumeOfPurchases { get; set; }

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


        public ICollection<Sale> Sales { get; set; }
    }

}
