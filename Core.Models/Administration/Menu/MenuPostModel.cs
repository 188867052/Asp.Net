﻿using System;
using Core.Entity.Enums;

namespace Core.Model.Administration.Menu
{
    /// <summary>
    ///
    /// </summary>
    public class MenuPostModel : Pager
    {
        /// <summary>
        /// 菜单名称.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 链接地址.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 页面别名.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 菜单图标(可选).
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 父级ID.
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 上级菜单名称.
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 菜单层级深度.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 描述信息.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 排序.
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 是否可用(0:禁用,1:可用).
        /// </summary>
        public StatusEnum Status { get; set; }

        /// <summary>
        /// 是否已删.
        /// </summary>
        public IsDeletedEnum IsDeleted { get; set; }

        /// <summary>
        /// 是否为默认路由.
        /// </summary>
        public YesOrNoEnum IsDefaultRouter { get; set; }

        /// <summary>
        /// 开始创建时间.
        /// </summary>
        public DateTime? StartCreateTime { get; set; }

        /// <summary>
        /// 结束创建时间.
        /// </summary>
        public DateTime? EndCreateTime { get; set; }
    }
}
