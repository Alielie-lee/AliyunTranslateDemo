using System;
using System.Collections.Generic;
using System.Text;

namespace NiuTranslate.Models
{
    /// <summary>
    /// 双语对照返回字段
    /// </summary>
    public class TranslateAlignResponse : BaseResponse
    {
        /// <summary>
        /// 对照数据
        /// </summary>
        public List<TranslateAlignItem> Align { get; set; }
    }

    public class TranslateAlignItem
    {
        /// <summary>
        /// 原句
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        /// 译句
        /// </summary>
        public string Tgt { get; set; }
    }
}
