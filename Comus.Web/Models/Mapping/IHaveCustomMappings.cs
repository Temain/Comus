using AutoMapper;

namespace Comus.Web.Models.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
