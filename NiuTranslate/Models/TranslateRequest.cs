using Newtonsoft.Json;
using NiuTranslate.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiuTranslate.Models
{
    [Serializable]
    /// <summary>
    /// 翻译请求参数
    /// </summary>
    public class TranslateRequest
    {
        /// <summary>
        /// 源语言：待翻译文本语种参数 
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; } = "auto";
        /// <summary>
        /// 目标语言：翻译目标语种参数
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; } = "en";
        /// <summary>
        /// API密钥
        /// </summary>
        [JsonProperty("apikey")]
        public string Apikey { get; set; }
        /// <summary>
        /// 待翻译字符串 该字段必须为UTF-8编码
        /// </summary>
        [JsonProperty("src_text")]
        public string Src_text { get; set; }
        /// <summary>
        /// 设置术语词典子库ID，缺省值为空
        /// </summary>
        [JsonProperty("dictNo")]
        public string DictNo { get; set; } = null;
        /// <summary>
        /// 设置翻译记忆子库ID，缺省值为空
        /// </summary>
        [JsonProperty("memoryNo")]
        public string MemoryNo { get; set; } = null;
        /// <summary>
        /// 1表示使用当前词典，0表示不使用当前词典
        /// </summary>
        [JsonProperty("dictflag")]
        public string Dictflag { get; set; } = "0";
        /// <summary>
        /// Json字典格式字符串，表示此条句子中使用到的词典（不支持一词多译文方式）
        /// </summary>
        [JsonProperty("dict")]
        public string Dict { get; set; } = null;


    }
}
