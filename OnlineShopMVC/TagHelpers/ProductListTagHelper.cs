using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using OnlineShopMVC.Models;

namespace OnlineShopMVC.TagHelpers
{
    public class ProductListTagHelper : TagHelper
    {
        public List<Product> Products { get; set; }
        public int FontSize { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Products == null)
                return;

            output.TagName = "ol";
            string listContent = "";
            string productInfo;

            foreach (Product product in Products)
            {
                productInfo = $@"<b>Title:</b> {product.Title}, 
                                <b>Price:</b> {product.Price}, 
                                <b>Producer:</b> {product.Producer}, 
                                <b>Type:</b> {product.Type}, 
                                <b>Amount:</b> {product.Amount}";
                listContent += "<li>" + productInfo + "</li>";
            }

            output.Attributes.SetAttribute("style", $"font-size:{FontSize}px;");
            output.Content.SetHtmlContent(listContent);
        }
    }
}
