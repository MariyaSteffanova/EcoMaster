namespace Econom.Web.Areas.Private.ViewModels
{

    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Econom.Data.Models;
    using Econom.Web.Infrastructure.Mapping;

    public class HomeStorageViewModel : IMapFrom<HomeStorage>, IHaveCustomMappings
    {
        public string Country { get; set; }

        public string Town { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string Address { get; set; }

        public ICollection<string> FlatmatesEmails { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<HomeStorage, HomeStorageViewModel>()
                 .ForMember(x => x.FlatmatesEmails, opt => opt.MapFrom(x => x.Owners.Select(o => o.Email)));


        }
    }
}
