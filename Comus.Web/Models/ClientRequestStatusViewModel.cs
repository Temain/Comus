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
    /// Ствтус заявки
    /// </summary>
    public class ClientRequestStatusViewModel : IHaveCustomMappings
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ClientRequestStatusId { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string ClientRequestStatusName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ClientSource, ClientSourceViewModel>("ClientRequestStatus");
        }
    }

}
