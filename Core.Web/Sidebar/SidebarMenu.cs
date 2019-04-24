﻿namespace Core.Web.Sidebar
{
    public class LinkedAnchor
    {
        public LinkedAnchor(string url, string innerText, string @class = default)
        {
            this.Url = url;
            this.InnerText = innerText;
            this.Class = @class;
        }
        public string Class { get; set; }
        public string InnerText { get; set; }

        public string Url { get; set; }

        public string Render()
        {
            return $"<li><a href=\"{this.Url}\">{this.InnerText}</a></li>";
        }
    }
}
