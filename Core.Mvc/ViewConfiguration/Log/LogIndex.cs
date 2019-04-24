﻿using Core.Extension;
using Core.Model.ResponseModels;
using Core.Resource.ViewConfiguration.Error;
using Core.Web.Sidebar;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Mvc.ViewConfiguration.Log
{
    public class LogIndex : IndexBase
    {
        private readonly List<Model.Entity.Log> _errors;

        public LogIndex(IHostingEnvironment hostingEnvironment) : base(hostingEnvironment)
        {
            Task<ResponseModel> a = AsyncRequest.GetAsync<IList<Model.Entity.Log>>("/error");
            this._errors = (List<Model.Entity.Log>)a.Result.Data;
        }

        public override IList<string> Css()
        {
            return new List<string>
            {
                "/css/uniform.css",
                "/css/select2.css",
                "/css/matrix-style.css",
                "/css/matrix-media.css",
                "/font-awesome/css/font-awesome.css",

                "/css/Log/Log.css",
            };
        }

        protected override string FileName
        {
            get
            {
                return "Manage";
            }
        }

        protected override IList<string> Javascript()
        {
            return new List<string>
            {
               "/js/jquery.ui.custom.js",
               "/js/select2.min.js",
               "/js/jquery.dataTables.min.js",
               "/js/matrix.js",
               //"/js/matrix.tables.js",

               "/lib/jquery/dist/jquery.js",
               "/js/bootstrap-datetimepicker.js",
            };
        }

        public override string Render()
        {
            LogViewConfiguration configuration = new LogViewConfiguration(this._errors);
            string table = configuration.Render();
            LogSearchGridFilterConfiguration filter = new LogSearchGridFilterConfiguration();

            var html = base.Render().Replace("{{Table}}", table);
            html = html.Replace("{{widget-title}}", ErrorResource.Header);
            html = html.Replace("{{grid-search-filter}}", filter.GenerateSearchFilter());
            html = html.Replace("{{button-group}}", filter.GenerateButton());

            return html;
        }

        protected override string ContentHeader()
        {
            ContentHeader contentHeader = new ContentHeader(ErrorResource.Header);
            contentHeader.AddAnchor(new Anchor("/Redirect/index", "Home", "Go to Home", "Error-home", "tip-bottom"));
            string html = contentHeader.Render();
            return html;
        }
    }
}