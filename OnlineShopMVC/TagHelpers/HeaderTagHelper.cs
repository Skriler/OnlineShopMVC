using Microsoft.AspNetCore.Razor.TagHelpers;
using OnlineShopMVC.Models;

namespace OnlineShopMVC.TagHelpers
{
    [HtmlTargetElement("custom-header")]
    public class HeaderTagHelper : TagHelper
    {
        public StyleInfo StyleInfo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h1";

            if (StyleInfo != null)
            {
                string style = $@"color:{StyleInfo.Color};
                             font-size:{StyleInfo.FontSize}px;
                             font-family:{StyleInfo.FontFamily};";
                output.Attributes.SetAttribute("style", style);
            }
        }
    }
}
