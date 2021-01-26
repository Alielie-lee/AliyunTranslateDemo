using AlibabaCloud.SDK.Alimt20181012.Models;
using AliyunPackage.Translate.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliyunPackage.Translate
{
    /// <summary>
    /// 图片翻译
    /// </summary>
    public class ImageTranslate : ClientInit
    {
        public ImageTranslate(string accessKeyId, string accessKeySecret) : base(accessKeyId, accessKeySecret, "mt")
        {
        }
        /// <summary>
        /// 获取翻译结果
        /// </summary>
        /// <param name="url">图片地址</param>
        /// <param name="sourceLanguage">原文语言</param>
        /// <param name="targetLanguage">译文语言</param>
        /// <param name="extra"></param>
        /// <returns></returns>
        public async Task<GetImageTranslateResponse> GetImageTranslate(string url, LanguageEnum sourceLanguage = LanguageEnum.中文, LanguageEnum targetLanguage = LanguageEnum.英语, string extra = null)
        {
            GetImageTranslateRequest getImageTranslateRequest = new GetImageTranslateRequest()
            {
                Url = url,
                SourceLanguage = sourceLanguage.GetDescription(),
                TargetLanguage = targetLanguage.GetDescription(),
                Extra = extra
            };
            return await BaseClient.GetImageTranslateSimplyAsync(getImageTranslateRequest);
        }
    }
}
