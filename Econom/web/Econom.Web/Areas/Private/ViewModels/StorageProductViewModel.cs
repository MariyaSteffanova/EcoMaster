using Econom.Data.Models;
using Econom.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Econom.Web.Areas.Private.ViewModels
{
    // TODO: EcoInfo
    public class StorageProductViewModel : IMapFrom<StorageProduct>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Percentage { get; set; }

        public decimal EcoNotes { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<StorageProduct, StorageProductViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(m => m.Product.Name))
                .ForMember(x => x.Percentage, opt => opt.MapFrom(m => m.Product.EcoInfo == null ? 0 : m.Product.EcoInfo.Percentage))
                .ForMember(x => x.EcoNotes, opt => opt.MapFrom(m => m.Product.EcoInfo == null ? "No information for this product" : m.Product.EcoInfo.Notes));
        }
    }
}
