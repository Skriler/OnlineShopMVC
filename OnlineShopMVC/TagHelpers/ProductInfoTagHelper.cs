using Microsoft.AspNetCore.Razor.TagHelpers;
using OnlineShopMVC.Models;

namespace OnlineShopMVC.TagHelpers
{
    public class ProductInfoTagHelper : TagHelper
    {
        public Product Product { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Product == null)
                return;

            output.TagName = "div";
            string content = $@"<p>Title: <b>{Product.Title}</b></p>
                                <p>Price: <b>{Product.Price}</b></p>
                                <p>Producer: <b>{Product.Producer}</b></p>
                                <p>Type: <b>{Product.Type}</b></p>
                                <p>Amount: <b>{Product.Amount}</b></p>";
            output.Content.SetHtmlContent(content);
        }
    }
}
