namespace Econom.Web.Areas.Private.ViewModels
{
    using Econom.Data.Models;
    using Econom.Web.Infrastructure.Mapping;
    using AutoMapper;
    using System;
    using System.ComponentModel.DataAnnotations;    // TODO: Image
    public class StorageProductViewModel : IMapFrom<StorageProduct>, IHaveCustomMappings
    {
        [Editable(false)]
        public int ID { get; set; }

        [Editable(false)]
        public int ProductID { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Percentage { get; set; }

        public string EcoNotes { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<StorageProduct, StorageProductViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(m => m.Product.Name))
                .ForMember(x => x.Percentage, opt => opt.MapFrom(m => m.Product.EcoInfo == null ? 0 : m.Product.EcoInfo.Percentage))
                .ForMember(x => x.EcoNotes, opt => opt.MapFrom(m => m.Product.EcoInfo == null ? "No information for this product" : m.Product.EcoInfo.Notes));
        }
    }
}
