using AutoMapper;
using Comus.Web.Models.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comus.Domain.Models
{
    /// <summary>
    /// Статус клиента
    /// </summary>
    public class ClientStatusViewModel : IHaveCustomMappings
    {
        public int ClientStatusId { get; set; }
        public string ClientStatusName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ClientStatus, ClientStatusViewModel>("ClientStatus");
        }
    }
}
