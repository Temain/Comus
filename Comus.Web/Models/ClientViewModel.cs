using System;
using System.Collections.Generic;
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
        /// Средний объем закупок
        /// </summary>
        public decimal? VolumeOfPurchases { get; set; }

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
        /// Ответственный менеджер
        /// </summary>
        public int? EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Источник привлечения
        /// </summary>
        public int? ClientSourceId { get; set; }
        public string ClientSourceName { get; set; }
        public List<ClientSourceViewModel> ClientSources { get; set; }

        /// <summary>
        /// Тип продукции
        /// </summary>
        public int? ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public List<ProductTypeViewModel> ProductTypes { get; set; }

        /// <summary>
        /// Статус клиента
        /// </summary>
        public int? ClientStatusId { get; set; }
        public string ClientStatusName { get; set; }
        public List<ClientStatusViewModel> ClientStatuses { get; set; }


        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Client, ClientViewModel>("Client")
                .ForMember(m => m.ClientFullName, opt => opt.MapFrom(s => s.Person.ShortName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(s => s.Person.LastName))
                .ForMember(m => m.FirstName, opt => opt.MapFrom(s => s.Person.FirstName))
                .ForMember(m => m.MiddleName, opt => opt.MapFrom(s => s.Person.MiddleName))
                .ForMember(m => m.EmployeeFullName, opt => opt.MapFrom(s => s.Employee.Person.ShortName))
                .ForMember(dest => dest.ClientSourceName, opt => opt.MapFrom(src => src.ClientSource.ClientSourceName))
                .ForMember(dest => dest.ClientStatusName, opt => opt.MapFrom(src => src.ClientStatus.ClientStatusName))
                .ForMember(dest => dest.ProductTypeName, opt => opt.MapFrom(src => src.ProductType.ProductTypeName));

            configuration.CreateMap<ClientViewModel, Client>("Client")
                .ForMember(m => m.Person, opt => opt.MapFrom(s => s));

            configuration.CreateMap<ClientViewModel, Person>("Client");
        }
    }

}
