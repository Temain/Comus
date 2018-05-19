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
    /// Источник привлечения клиента
    /// </summary>
    public class ClientSourceViewModel : IHaveCustomMappings
    {
        public int ClientSourceId { get; set; }
        public string ClientSourceName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ClientSource, ClientSourceViewModel>("ClientSource");
        }
    }
}
