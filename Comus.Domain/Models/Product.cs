﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Comus.Domain.Models
{
    /// <summary>
    /// Товар
    /// </summary>
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Тип продукции
        /// </summary>
        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Количество в наличии / на складе
        /// </summary>
        public int InStock { get; set; }

        /// <summary>
        /// Склад
        /// </summary>
        public string Warehouse { get; set; }

        /// <summary>
        /// Максимальная вместимость
        /// </summary>
        public string MaxCapacity { get; set; }

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
