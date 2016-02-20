namespace Econom.Web.Areas.Private.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;

    using Econom.Data.Models;
    using Econom.Web.Infrastructure.Mapping;
    using System.ComponentModel;
    public class HomeStorageInputModel : IMapTo<HomeStorage>, IMapFrom<HomeStorage>, IHaveCustomMappings
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string Town { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string Address { get; set; }

        [IgnoreMap]
        public ICollection<string> FlatmatesEmails { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<HomeStorageInputModel, HomeStorage>()
                 .ForMember(x => x.Location, opt => opt.MapFrom(x => new Location
                 {
                     Country = x.Country,
                     Town = x.Town,
                     Street = x.Street,
                     StreetNumber = x.StreetNumber
                 }));

            configuration.CreateMap<HomeStorage, HomeStorageInputModel>()
               .ForMember(x => x.FlatmatesEmails, opt => opt.MapFrom(x => x.Owners.Select(o => o.Email)))
               .ForMember(x => x.Country, opt => opt.MapFrom(l => l.Location.Country))
               .ForMember(x => x.Town, opt => opt.MapFrom(l => l.Location.Town))
               .ForMember(x => x.Street, opt => opt.MapFrom(l => l.Location.Street))
               .ForMember(x => x.StreetNumber, opt => opt.MapFrom(l => l.Location.StreetNumber));

        }
    }
}
