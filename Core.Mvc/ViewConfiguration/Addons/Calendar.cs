﻿using System.Collections.Generic;
using Core.Mvc.ViewConfiguration.Landing;
using Core.Web.Sidebar;
using Microsoft.AspNetCore.Hosting;

namespace Core.Mvc.ViewConfiguration.Addons
{
    public class Calendar : IndexBase
    {
        public Calendar(IHostingEnvironment hostingEnvironment) : base(hostingEnvironment)
        {

        }

        protected override string FileName
        {
            get
            {
                return "Calendar";
            }
        }

        public override IList<string> Css()
        {
            return new List<string>
            {
                "/css/matrix-style.css",
                "/css/matrix-media.css",
                "/font-awesome/css/font-awesome.css",
                "/css/fullcalendar.css"
            };
        }

        protected override IList<string> Javascript()
        {
            return new List<string>
            {
               
               "/js/matrix.js",
               "/js/fullcalendar.min.js",
               "/js/matrix.calendar.js"
            };
        }

        protected override string ContentHeader()
        {
            ContentHeader contentHeader = new ContentHeader("Calendar");
            contentHeader.AddAnchor(new Anchor("/Redirect/index", "Home", "Go to Home", "icon-home", "tip-bottom"));
            return contentHeader.Render();
        }
    }
}