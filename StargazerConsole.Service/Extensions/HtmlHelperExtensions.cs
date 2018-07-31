using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace StargazerConsole.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent ImageButton<TModel>(
            this IHtmlHelper<TModel> helper,
            string name,
            string imagePath,
            string titleText,
            string clickFunctionName = null,
            int? width = null,
            int? height = null,
            Dictionary<string, string> additionalAttributes = null)
        {
            
            var returnWriter = new HtmlContentBuilder();

            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("image-button-container");

            var innerDivBuilder = new TagBuilder("div");

            
            var imgBuilder = new TagBuilder("img");
            imgBuilder.AddCssClass("image-button-image");
            imgBuilder.Attributes.Add("name", name);
            imgBuilder.Attributes.Add("src", imagePath);
            imgBuilder.Attributes.Add("title", titleText);

            if (!String.IsNullOrEmpty(clickFunctionName))
            {
                imgBuilder.Attributes.Add("onclick", clickFunctionName);
            }

            if (width.HasValue)
            {
                imgBuilder.Attributes.Add("width", width.Value.ToString());
            }

            if (height.HasValue)
            {
                imgBuilder.Attributes.Add("height", height.Value.ToString());
            }

            if (additionalAttributes != null)
            {
                foreach (var attribute in additionalAttributes)
                {
                    imgBuilder.Attributes.Add(attribute.Key, attribute.Value);
                }
            }

            divBuilder.InnerHtml.AppendHtml(imgBuilder.RenderSelfClosingTag());

            return divBuilder;
        }
    }
}
