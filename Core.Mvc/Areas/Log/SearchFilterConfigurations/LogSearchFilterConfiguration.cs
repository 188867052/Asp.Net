﻿using System.Collections.Generic;
using Core.Entity.Enums;
using Core.Model.Log;
using Core.Mvc.Areas.Log.Routes;
using Core.Web.Button;
using Core.Web.GridFilter;
using Core.Web.SearchFilterConfiguration;
using Microsoft.Extensions.Logging;
using Resources = Core.Mvc.Resource.Areas.Log.SearchFilterConfigurations.LogSearchFilterConfigurationResource;

namespace Core.Mvc.Areas.Log.SearchFilterConfigurations
{
    public class LogSearchFilterConfiguration<T> : SearchFilterConfiguration
        where T : LogPostModel
    {
        protected override void CreateSearchFilter(IList<BaseGridFilter> searchFilter)
        {
            var logLevelDropDown = new DropDownGridFilter<T, LogLevel>(o => (LogLevel)o.LogLevel, Resources.LogLevel);
            logLevelDropDown.AddOption(LogLevel.Error, Resources.Error);
            logLevelDropDown.AddOption(LogLevel.Information, Resources.Information);
            logLevelDropDown.AddOption(LogLevel.Debug, Resources.Debug);

            var sqlTypeDropDown = new DropDownGridFilter<T, SqlTypeEnum>(o => (SqlTypeEnum)o.SqlType, Resources.SqlType);
            sqlTypeDropDown.AddOption(SqlTypeEnum.Select, Resources.Select);
            sqlTypeDropDown.AddOption(SqlTypeEnum.Create, Resources.Create);
            sqlTypeDropDown.AddOption(SqlTypeEnum.Update, Resources.Update);
            sqlTypeDropDown.AddOption(SqlTypeEnum.Delete, Resources.Delete);
            sqlTypeDropDown.AddOption(SqlTypeEnum.Insert, Resources.Insert);

            searchFilter.Add(new IntegerGridFilter<T>(o => o.Id, Resources.ID, Resources.ID));
            searchFilter.Add(new TextGridFilter<T>(o => o.Message, Resources.Message, Resources.Message));
            searchFilter.Add(new DateTimeGridFilter<T>(o => o.StartTime, Resources.StartTime, Resources.StartTime));
            searchFilter.Add(new DateTimeGridFilter<T>(o => o.EndTime, Resources.EndTime, Resources.EndTime));
            searchFilter.Add(logLevelDropDown);
            searchFilter.Add(sqlTypeDropDown);
        }

        protected override void CreateButton(IList<StandardButton> buttons)
        {
            buttons.Add(new StandardButton(Resources.SearchButtonLabel, "index.search", LogRoute.GridStateChange, Resources.SearchButtonLabel));
            buttons.Add(new StandardButton(Resources.ClearButtonLabel, "index.clear", LogRoute.Index, Resources.ClearButtonToolTip));
            buttons.Add(new StandardButton(Resources.ClearEmptyButtonLabel, "core.clear", tooltip: Resources.ClearEmptyButtonToolTip));
        }
    }
}
