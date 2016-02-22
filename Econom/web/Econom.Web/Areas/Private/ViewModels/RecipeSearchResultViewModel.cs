namespace Econom.Web.Areas.Private.ViewModels
{
    using Infrastructure.Mapping;
    using Services.TransferModels;
    using System;
    using System.Collections.Generic;
    using AutoMapper;

    public class RecipeSearchResultViewModel : IMapFrom<RecipeResult>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public decimal SocialRank { get; set; }

        public List<string> Ingredients { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<RecipeResult, RecipeSearchResultViewModel>()
                 .ForMember(x => x.Id, opt => opt.MapFrom(m => m.Food2ForkID))
                 .ForMember(x => x.SocialRank, opt => opt.MapFrom(m => Convert.ToDecimal(m.SocialRank)));
        }
    }
}
