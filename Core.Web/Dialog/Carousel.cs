﻿namespace Core.Web.Dialog
{
    public class Carousel
    {
        private string html = System.IO.File.ReadAllText(@"C:\Users\54215\Desktop\Study\Asp.Net\Core.Web\File\Carousel.html");

        public Carousel()
        {

        }

        public string Render()
        {
            return this.html;
        }
    }
}