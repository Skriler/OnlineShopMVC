using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace OnlineShopMVC.TagHelpers
{
    public class DateTagHelper : TagHelper
    {
        public string Color { get; set; }
        public bool IsMonthFirstFormat { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string date;

            output.TagName = "div";

            if (IsMonthFirstFormat)
                date = DateTime.Now.ToString("MM/dd/yyyy");
            else
                date = DateTime.Now.ToString("dd/MM/yyyy");

            output.Content.SetContent($"Current date: {date}");
            output.Attributes.SetAttribute("style", $"color:{Color};");
        }
    }
}
