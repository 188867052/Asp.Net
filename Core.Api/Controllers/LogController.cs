﻿using System;
using System.Linq;
using System.Net;
using AutoMapper;
using Core.Api.ControllerHelpers;
using Core.Entity;
using Core.Extension;
using Core.Extension.CustomException;
using Core.Model;
using Core.Model.Log;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    /// <summary>
    ///
    /// </summary>
    public class LogController : StandardController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogController"/> class.
        /// </summary>
        /// <param name="dbContext">The dbContext.</param>
        /// <param name="mapper">The mapper.</param>
        public LogController(CoreApiContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (this.DbContext)
            {
                IQueryable<Log> query = this.DbContext.Log;
                query = query.OrderByDescending(o => o.CreateTime);
                return this.StandardResponse(query);
            }
        }

        [HttpPost]
        public IActionResult Search(LogPostModel model)
        {
            using (this.DbContext)
            {
                IQueryable<Log> query = this.DbContext.Log;
                if (model.LogLevel.HasValue)
                {
                    query = query.Where(o => o.LogLevel == (int)model.LogLevel.Value);
                }

                query = query.OrderByDescending(o => o.CreateTime);
                query = query.AddIntegerEqualFilter(model.Id, o => o.Id);
                query = query.AddDateTimeBetweenFilter(model.StartTime, model.EndTime, o => o.CreateTime);
                query = query.AddStringContainsFilter(model.Message, o => o.Message);

                return this.StandardResponse(query, model);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpGet]
        public IActionResult Code(int code)
        {
            // 捕获状态码
            HttpStatusCode statusCode = this.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error is HttpException httpEx ?
                httpEx.StatusCode : (HttpStatusCode)this.Response.StatusCode;
            HttpException ex = (HttpException)this.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            HttpStatusCode parsedCode = (HttpStatusCode)code;
            ErrorDetails error = new ErrorDetails
            {
                StatusCode = code,
                Message = ex?.ToString()
            };

            // 如果是ASP.NET Core Web Api 应用程序，直接返回状态码(不跳转到错误页面，这里假设所有API接口的路径都是以/api/开始的)
            if (this.HttpContext.Features.Get<IHttpRequestFeature>().RawTarget.StartsWith("/api/", StringComparison.Ordinal))
            {
                parsedCode = (HttpStatusCode)code;

                // error = new ErrorDetails
                // {
                //    StatusCode = code,
                //    Message = parsedCode.ToString()
                // };
                return new ObjectResult(error);
            }
            ////IQueryable<Role> query = this.DbContext.Role;
            // List<Role> a = query.ToList();
            //// error = new ErrorDetails
            ////{
            ////    StatusCode = code,
            ////    Message = parsedCode.ToString()
            ////};

            return new ObjectResult(null);
        }

        /// <summary>
        /// 删除用户.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult Clear()
        {
            ResponseModel response = LogControllerHelper.DeleteAll();
            return this.Ok(response);
        }
    }
}