using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.IO;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopMVC.Models;

namespace OnlineShopMVC.Services
{
    public static class HtmlHelper
    {
        private static readonly string EMAIL_DOMAIN = "gmail.com";

        public static HtmlString CreateCustomHeader(this IHtmlHelper html, string content, StyleInfo styleInfo)
        {
            TagBuilder h1 = new TagBuilder("h1");
            h1.InnerHtml.Append(content);

            if (styleInfo != null)
            {
                string style = $@"color:{styleInfo.Color};
                             font-size:{styleInfo.FontSize}px;
                             font-family:{styleInfo.FontFamily};";
                h1.Attributes.Add("style", style);
            }

            StringWriter writer = new StringWriter();
            h1.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }

        public static HtmlString CreateCurrentDate(this IHtmlHelper html, string color, bool isMonthFirstFormat = false)
        {
            string date;

            TagBuilder div = new TagBuilder("div");

            if (isMonthFirstFormat)
                date = DateTime.Now.ToString("MM/dd/yyyy");
            else
                date = DateTime.Now.ToString("dd/MM/yyyy");

            div.InnerHtml.Append($"Current date: {date}");
            div.Attributes.Add("style", $"color:{color};");

            StringWriter writer = new StringWriter();
            div.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }

        public static HtmlString CreateEmailLink(this IHtmlHelper html, string mailTo, StyleInfo styleInfo)
        {
            TagBuilder a = new TagBuilder("a");

            string address = mailTo + "@" + EMAIL_DOMAIN;
            a.Attributes.Add("href", $"mailto: {address}");
            a.InnerHtml.Append(address);

            if (styleInfo != null)
            {
                string style = $@"color:{styleInfo.Color};
                             font-size:{styleInfo.FontSize}px;
                             font-family:{styleInfo.FontFamily};";
                a.Attributes.Add("style", style);
            }

            StringWriter writer = new StringWriter();
            a.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }

        public static HtmlString CreateProductInfo(this IHtmlHelper html, Product product)
        {
            TagBuilder div = new TagBuilder("div");

            string content = $@"<p>Title: <b>{product.Title}</b></p>
                                <p>Price: <b>{product.Price}</b></p>
                                <p>Producer: <b>{product.Producer}</b></p>
                                <p>Type: <b>{product.Type}</b></p>
                                <p>Amount: <b>{product.Amount}</b></p>";
            div.InnerHtml.AppendHtml(content);

            StringWriter writer = new StringWriter();
            div.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }

        public static HtmlString CreateProductList(this IHtmlHelper html, List<Product> products, int fontSize)
        {
            TagBuilder ol = new TagBuilder("ol");

            string productInfo;
            TagBuilder li;

            foreach (Product product in products)
            {
                productInfo = $@"<b>Title:</b> {product.Title}, 
                                <b>Price:</b> {product.Price}, 
                                <b>Producer:</b> {product.Producer}, 
                                <b>Type:</b> {product.Type}, 
                                <b>Amount:</b> {product.Amount}";

                li = new TagBuilder("li");
                li.InnerHtml.AppendHtml(productInfo);
                ol.InnerHtml.AppendHtml(li);
            }
            ol.Attributes.Add("style", $"font-size:{fontSize}px;");

            StringWriter writer = new StringWriter();
            ol.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }
    }
}
