using Econom.Data.Models;
using Econom.Web.Infrastructure.Mapping;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Econom.Web.Areas.Admin.ViewModels
{
    public class ProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        [Editable(false)]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Barcode { get; set; }

        public string ImageUrl { get; set; } // TODO: Decide how to keep the images

        public string Category { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
