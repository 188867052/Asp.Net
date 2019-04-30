﻿using System.Collections.Generic;
using System.Text;
using Core.Web.Button;
using Core.Web.GridFilter;

namespace Core.Mvc.ViewConfiguration
{
    public abstract class GridFilterConfiguration<T>
    {
        public string GenerateSearchFilter()
        {
            var searchFilter = new List<BaseGridFilter>();
            this.CreateSearchFilter(searchFilter);
            StringBuilder filterText = new StringBuilder();
            foreach (var item in searchFilter)
            {
                filterText.Append(item.Render());
            }

            return filterText.ToString();
        }

        protected abstract void CreateSearchFilter(IList<BaseGridFilter> searchFilter);

        protected abstract void CreateButton(IList<StandardButton> buttons);

        public string GenerateButton()
        {
            IList<StandardButton> buttons = new List<StandardButton>();
            this.CreateButton(buttons);
            ;
            string html = default;
            string script = default;
            foreach (var button in buttons)
            {
                html += button.Render();
                script += button.Event.Render();
            }

            script = $"<script>{script}</script>";
            return html + script;
        }
    }
}