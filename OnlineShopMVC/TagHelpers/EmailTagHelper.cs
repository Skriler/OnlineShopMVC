using Microsoft.AspNetCore.Razor.TagHelpers;
using OnlineShopMVC.Models;

namespace OnlineShopMVC.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        private static readonly string EMAIL_DOMAIN = "gmail.com";

        public string MailTo { get; set; }
        public StyleInfo StyleInfo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            string address = MailTo + "@" + EMAIL_DOMAIN;
            output.Attributes.SetAttribute("href", $"mailto: {address}");
            output.Content.SetContent(address);

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
