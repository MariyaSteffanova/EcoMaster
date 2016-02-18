﻿using System;
using AutoMapper;
using Econom.Data.Models;
using Econom.Web.Infrastructure.Mapping;

namespace Econom.Web.Areas.Private.ViewModels
{
    public class FlatmateViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, FlatmateViewModel>()
                  .ForMember(x => x.Name, opt => opt.MapFrom(u => u.FirstName + " " + u.LastName));
        }
    }
}
