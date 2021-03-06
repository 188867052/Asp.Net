﻿namespace Core.Model.Administration.Icon
{
    /// <summary>
    /// 图标请求参数实体.
    /// </summary>
    public class IconPostedModel : Pager
    {
        /// <summary>
        /// 是否可用.
        /// </summary>
        public bool? IsEnable { get; set; }

        /// <summary>
        /// 状态(正常,已禁用).
        /// </summary>
        public bool? Status { get; set; }
    }
}
