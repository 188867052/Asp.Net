﻿using Core.Resource.ViewConfiguration.Log;
using Core.Web.GridFilter;
using System;
using System.Collections.Generic;
using Core.Web.Button;

namespace Core.Mvc.ViewConfiguration.Log
{
    public class LogSearchGridFilterConfiguration : GridFilterConfiguration
    {
        public LogSearchGridFilterConfiguration()
        {
                this.Buttons=new List<StandardButton>();
        }
        public override string GenerateSearchFilter()
        {
            var filter = new GridSearchFilter();
            filter.AddTextFilter(new TextGridFilter(LogResource.ID));
            filter.AddTextFilter(new TextGridFilter(LogResource.Message));
            filter.AddDateTimeFilter(new DateTimeGridFilter("开始"+LogResource.CreateTime));
            filter.AddDateTimeFilter(new DateTimeGridFilter("结束" + LogResource.CreateTime));
            filter.AddDropDownGridFilter(new DropDownGridFilter("天数"));
            filter.AddDropDownGridFilter(new DropDownGridFilter("价格"));
            return filter.Render();
        }

        public override string GenerateButton()
        {
            this.Buttons.Add(new StandardButton("搜索"));
            this.Buttons.Add(new StandardButton("添加"));
            this.Buttons.Add(new StandardButton("编辑"));
            string html = default;
            foreach (var button in Buttons)
            {
                html += button.Render();
            }

            return html;
        }
    }
}