namespace Econom.Web.Areas.Private.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;

    using Econom.Data.Models;
    using Econom.Web.Infrastructure.Mapping;

    public class HomeStorageInputModel : IMapFrom<HomeStorage>, IHaveCustomMappings
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string Town { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string Address { get; set; }

        public ICollection<string> FlatmatesEmails { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<HomeStorage, HomeStorageInputModel>()
                 .ForMember(x => x.FlatmatesEmails, opt => opt.MapFrom(x => x.Owners.Select(o => o.Email)));
        }
    }
}
