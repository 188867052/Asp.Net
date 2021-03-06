﻿using System.Collections.Generic;
using Core.Model.Administration.Menu;
using Core.Mvc.Areas.Administration.Routes;
using Core.Web.Button;
using Core.Web.Dialog;
using Core.Web.Html;
using Core.Web.TextBox;
using Resources = Core.Mvc.Resource.Areas.Administration.ViewConfiguration.Menu.AddMenuDialogConfigurationResource;

namespace Core.Mvc.Areas.Administration.ViewConfiguration.Menu
{
    public class AddMenuDialogConfiguration<TPostModel, TModel> : DialogConfiguration<TPostModel, TModel>
        where TPostModel : MenuCreatePostModel
        where TModel : MenuModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddMenuDialogConfiguration{TPostModel, TModel}"/> class.
        /// </summary>
        public AddMenuDialogConfiguration() : base(MenuIdentifiers.AddMenuDialogIdentifier)
        {
        }

        public override string Title => Resources.AddMenuTitle;

        protected override void CreateBody(IList<IHtmlContent<TPostModel, TModel>> textBoxes)
        {
            textBoxes.Add(new LabeledTextBox<TPostModel, TModel>(Resources.Name, o => o.Name));
            textBoxes.Add(new LabeledTextBox<TPostModel, TModel>(Resources.Url, o => o.Url));
            textBoxes.Add(new LabeledTextBox<TPostModel, TModel>(Resources.Description, o => o.Description));
            textBoxes.Add(new LabeledIntegerBox<TPostModel, TModel>(Resources.Sort, o => o.Sort));
            textBoxes.Add(new LabeledTextBox<TPostModel, TModel>(Resources.Alias, o => o.Alias));
        }

        protected override void CreateHiddenValues(IList<IHtmlContent<TPostModel, TModel>> textBoxes)
        {
        }

        protected override void CreateButtons(IList<StandardButton> buttons)
        {
            buttons.Add(new StandardButton(Resources.Submit, "index.submit", MenuRoute.SaveCreate));
            buttons.Add(new StandardButton(Resources.Cancel, "core.cancel"));
        }
    }
}