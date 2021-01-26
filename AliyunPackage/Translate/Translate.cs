using AlibabaCloud.SDK.Alimt20181012.Models;
using AlibabaCloud.OpenApiClient;
using AlibabaCloud.OpenApiClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AliyunPackage.Translate.Enum;
using System.Threading.Tasks;

namespace AliyunPackage.Translate
{
    /// <summary>
    /// 通用翻译
    /// </summary>
    public class Translate : ClientInit
    {
        public Translate(string accessKeyId, string accessKeySecret) : base(accessKeyId, accessKeySecret, "mt")
        {

        }
        /// <summary>
        /// 获取翻译结果
        /// </summary>
        /// <param name="sourceText">翻译内容</param>
        /// <param name="sourceLanguage">原文语言</param>
        /// <param name="targetLanguage">译文语言</param>
        /// <param name="formatType">翻译文本的格式，html（ 网页格式。设置此参数将对待翻译文本以及翻译后文本按照html格式进行处理）、text（文本格式。设置此参数将对传入待翻译文本以及翻译后结果不做文本格式处理，统一按纯文本格式处理。</param>
        /// <returns></returns>
        public async Task<TranslateGeneralResponse> TranslateGeneral(string sourceText, LanguageEnum sourceLanguage = LanguageEnum.中文, LanguageEnum targetLanguage = LanguageEnum.英语, string formatType = "text")
        {
            TranslateGeneralRequest translateGeneralRequest = new TranslateGeneralRequest()
            {
                FormatType = formatType,
                SourceLanguage = sourceLanguage.GetDescription(),
                TargetLanguage = targetLanguage.GetDescription(),
                SourceText = sourceText,
                Scene = "general",
            };
            return await BaseClient.TranslateGeneralSimplyAsync(translateGeneralRequest);
        }
    }
}
