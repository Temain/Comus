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
    /// Тип продукции
    /// </summary>
    public class ProductTypeViewModel : IHaveCustomMappings
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ProductType, ProductTypeViewModel>("ProductType");
        }
    }
}
