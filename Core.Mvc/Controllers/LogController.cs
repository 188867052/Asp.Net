﻿using Core.Extension;
using Core.Model.Entity;
using Core.Model.PostModel;
using Core.Model.ResponseModels;
using Core.Mvc.ViewConfiguration.Log;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mvc.Controllers
{
    public class LogController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        public LogController(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var url = new Url(typeof(Api.Controllers.Log2Controller), nameof(Api.Controllers.Log2Controller.Index));
            Task<ResponseModel> model = AsyncRequest.GetAsync<IList<Log>>(url);
            var errors = (List<Log>)model.Result.Data;
            LogIndex table = new LogIndex(_hostingEnvironment, errors);
            return Content(table.Render(), "text/html", Encoding.UTF8);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GridStateChange(LogPostModel postModel)
        {
            var url = new Url(typeof(Api.Controllers.Log2Controller), nameof(Api.Controllers.Log2Controller.Search));
            Task<ResponseModel> model = AsyncRequest.PostAsync<IList<Log>, LogPostModel>(url, postModel);
            List<Log> logs = (List<Log>)model.Result.Data;
            LogIndex table = new LogIndex(_hostingEnvironment, logs);

            return Content(table.Render(), "text/html", Encoding.UTF8);
        }
    }
}