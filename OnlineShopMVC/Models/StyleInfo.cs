namespace OnlineShopMVC.Models
{
    public class StyleInfo
    {
        public string Color { get; set; }
        public string FontFamily { get; set; }
        public int FontSize { get; set; }

        public StyleInfo(string color, string fontFamily, int fontSize)
        {
            Color = color;
            FontFamily = fontFamily;
            FontSize = fontSize;
        }
    }
}
