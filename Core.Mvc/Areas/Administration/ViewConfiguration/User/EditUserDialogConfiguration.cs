﻿using System.Collections.Generic;
using Core.Model.Administration.User;
using Core.Model.Enums;
using Core.Web.Button;
using Core.Web.Dialog;
using Core.Web.Enums;
using Core.Web.Html;
using Core.Web.Identifiers;
using Core.Web.TextBox;

namespace Core.Mvc.Areas.Administration.ViewConfiguration.User
{
    public class EditUserDialogConfiguration : DialogConfiguration<UserEditPostModel, Model.Administration.User.User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditUserDialogConfiguration"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        public EditUserDialogConfiguration(Model.Administration.User.User user) : base(user, Identifier)
        {
        }

        public new static Identifier Identifier { get; } = new Identifier();

        public override string Title => "编辑用户";

        protected override void CreateHiddenValues(IList<ITextRender<UserEditPostModel, Model.Administration.User.User>> textBoxes)
        {
            textBoxes.Add(new HiddenTextBox<UserEditPostModel, Model.Administration.User.User>(o => o.Id, this.Model.Id));
        }

        protected override void CreateBody(IList<ITextRender<UserEditPostModel, Model.Administration.User.User>> textBoxes)
        {
            textBoxes.Add(new LabeledTextBox<UserEditPostModel, Model.Administration.User.User>("登录名", o => o.LoginName, o => o.LoginName));
            textBoxes.Add(new LabeledTextBox<UserEditPostModel, Model.Administration.User.User>("显示名", o => o.DisplayName, o => o.DisplayName));

            var dropDown = new DropDownTextBox<UserEditPostModel, Model.Administration.User.User>("角色", o => o.UserType, false);
            dropDown.AddOption((int)UserTypeEnum.GeneralUser, "一般用户");
            dropDown.AddOption((int)UserTypeEnum.Admin, "管理员");
            dropDown.AddOption((int)UserTypeEnum.SuperAdministrator, "超级管理员");
            textBoxes.Add(dropDown);
            textBoxes.Add(new LabeledTextBox<UserEditPostModel, Model.Administration.User.User>("密码", o => o.Password, o => o.Password, TextBoxTypeEnum.Password));
        }

        protected override void CreateButtons(IList<StandardButton> buttons)
        {
            buttons.Add(new StandardButton("提交", "index.submit"));
            buttons.Add(new StandardButton("取消", "core.cancel"));
        }
    }
}