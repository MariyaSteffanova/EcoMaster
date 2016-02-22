using Econom.Data.Models;
using Econom.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Econom.Common;

namespace Econom.Web.Areas.Admin.ViewModels
{
    public class UserViewModel : IMapFrom<User>, IMapTo<User>, IHaveCustomMappings
    {
        [Editable(false)]
        public string ID { get; set; }

        [Required]
        [MaxLength(GlobalConstants.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string ImageUrl { get; set; }

        [Editable(false)]
        public int FlatmatesCount { get; private set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Town { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                 .ForMember(x => x.Country, opt => opt.MapFrom(m => m.HomeStorage.Location.Country))
                 .ForMember(x => x.Town, opt => opt.MapFrom(m => m.HomeStorage.Location.Town))
                 .ForMember(x => x.FlatmatesCount, opt => opt.MapFrom(m => m.Flatmates.Count))
                 .IgnoreAllPropertiesWithAnInaccessibleSetter();

            configuration.CreateMap<UserViewModel, User>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.ID))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
