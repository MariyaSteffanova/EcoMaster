using Econom.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Econom.Web.HtmlHelpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Image(this HtmlHelper helper,
                                string url,
                                string altText,
                                object htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.Attributes.Add("src", url);
            builder.Attributes.Add("alt", altText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Image(this HtmlHelper helper,
                                byte[] imageBase64Data,
                                string altText,
                                object htmlAttributes)
        {
            var source = imageBase64Data == null ?
              VirtualPathUtility.ToAbsolute(GlobalConstants.DefaultProductImageSource) :
                string.Format("data:image/png;base64,{0}", Convert.ToBase64String(imageBase64Data));

            TagBuilder builder = new TagBuilder("img");
            builder.Attributes.Add("src", source);
            builder.Attributes.Add("alt", altText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}
