﻿using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Comus.Domain.Models;
using Comus.Web.Models.Mapping;

namespace Comus.Web.Models
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class ClientViewModel : IHaveCustomMappings
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
        /// Физическое лицо
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        [StringLength(500)]
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [StringLength(500)]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [StringLength(500)]
        public string MiddleName { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string ClientFullName { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }


        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Client, ClientViewModel>("Client")
                .ForMember(m => m.ClientFullName, opt => opt.MapFrom(s => s.Person.FullName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(s => s.Person.LastName))
                .ForMember(m => m.FirstName, opt => opt.MapFrom(s => s.Person.FirstName))
                .ForMember(m => m.MiddleName, opt => opt.MapFrom(s => s.Person.MiddleName));

            configuration.CreateMap<ClientViewModel, Client>("Client")
                .ForMember(m => m.Person, opt => opt.MapFrom(s => s));

            configuration.CreateMap<ClientViewModel, Person>("Client");
        }
    }

}
