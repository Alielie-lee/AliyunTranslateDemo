using NiuTranslate.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiuTranslate.Models
{
    /// <summary>
    /// 基础返回字段
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// 源语言：待翻译文本语种参数 
        /// </summary>
        public string From { get; set; } 
        /// <summary>
        /// 目标语言：翻译目标语种参数
        /// </summary>
        public string To { get; set; } 
        /// <summary>
        /// 翻译结果
        /// </summary>
        public string Tgt_text { get; set; }
        /// <summary>
        /// 待翻译字符串 该字段必须为UTF-8编码
        /// </summary>

        public string Src_text { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public int Error_code { get; set; } = 0;
        /// <summary>
        /// 错误说明
        /// </summary>
        public string Error_msg { get; set; }



    }
}
