namespace Econom.Web.Areas.Admin.ViewModels
{
    using System.Linq;
    using Econom.Data.Models;
    using Econom.Web.Infrastructure.Mapping;
    using System;
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;

    public class FoodStorageViewModel : IMapFrom<HomeStorage>, IHaveCustomMappings
    {
        [Editable(false)]
        public int ID { get; set; }

        public int OwnersCount { get; set; }

        public int ProductsCount { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public bool IsDeleted { get; set; }

        [Editable(false)]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<HomeStorage, FoodStorageViewModel>()
                 .ForMember(x => x.OwnersCount, opt => opt.MapFrom(m => m.Owners.Count))
                 .ForMember(x => x.ProductsCount, opt => opt.MapFrom(m => m.Products.Count(x=> !x.IsDeleted)))
                 .ForMember(x => x.Country, opt => opt.MapFrom(m => m.Location.Country))
                 .ForMember(x => x.Town, opt => opt.MapFrom(m => m.Location.Town));
        }
    }
}
