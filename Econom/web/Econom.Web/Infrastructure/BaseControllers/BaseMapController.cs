namespace Econom.Web.Infrastructure.BaseControllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Econom.Web.Infrastructure.Mapping;
    using Econom.Web.Infrastructure.BaseControllers;

    public class BaseMapController : BaseController
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}
