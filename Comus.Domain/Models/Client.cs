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

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        /// <summary>
        /// Тип продукции
        /// </summary>
        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Источник привлечения
        /// </summary>
        public int? ClientSourceId { get; set; }
        public ClientSource ClientSource { get; set; }

        /// <summary>
        /// Статус клиента
        /// </summary>
        public int? ClientStatusId { get; set; }
        public ClientStatus ClientStatus { get; set; }

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


        public List<Sale> Sales { get; set; }
    }

}
