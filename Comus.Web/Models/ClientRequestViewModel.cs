using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Comus.Web.Models.Mapping;
using Newtonsoft.Json;

namespace Comus.Domain.Models
{
    /// <summary>
    /// Заявка
    /// </summary>
    public class ClientRequestViewModel : IHaveCustomMappings
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
        public string PersonFullName { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Источник привлечения
        /// </summary>
        public int? ClientSourceId { get; set; }
        public string ClientSourceName { get; set; }

        /// <summary>
        /// Тип продукции
        /// </summary>
        public int? ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        /// <summary>
        /// Статус заявки
        /// </summary>
        public int? ClientRequestStatusId { get; set; }
        public string ClientRequestStatusName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ClientRequest, ClientRequestViewModel>("ClientRequest")
               .ForMember(m => m.ClientRequestStatusName, opt => opt.MapFrom(s => s.ClientRequestStatus.ClientRequestStatusName))
               .ForMember(m => m.PersonFullName, opt => opt.MapFrom(s => s.Person.FullName))
               .ForMember(dest => dest.ClientSourceName, opt => opt.MapFrom(src => src.ClientSource.ClientSourceName))
               .ForMember(dest => dest.ProductTypeName, opt => opt.MapFrom(src => src.ProductType.ProductTypeName));

            configuration.CreateMap<ClientRequestViewModel, ClientRequest>("ClientRequest")
                .ForMember(m => m.Person, opt => opt.MapFrom(s => s));

            configuration.CreateMap<ClientRequestViewModel, Person>("ClientRequest");
        }
    }

}
