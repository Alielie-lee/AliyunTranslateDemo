using NiuTranslate.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NiuTranslate
{
    /// <summary>
    /// 翻译服务
    /// </summary>
    public class TranslateServer
    {
        /// <summary>
        /// 免费翻译接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> TranslateFreeAsync(TranslateRequest request)
        {
            var url = "https://free.niutrans.com/NiuTransServer/translation";
            return await HttpHelper.PostAsync<BaseResponse>(url, Newtonsoft.Json.JsonConvert.SerializeObject(request));
        }
        /// <summary>
        /// 高级翻译接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> TranslateAsync(TranslateRequest request)
        {
            var url = "https://api.niutrans.com/NiuTransServer/translation";
            return await HttpHelper.PostAsync<BaseResponse>(url, Newtonsoft.Json.JsonConvert.SerializeObject(request));
        }
        /// <summary>
        /// 免费对照接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TranslateAlignResponse> TranslateAlignFreeAsync(TranslateRequest request)
        {
            var url = "https://free.niutrans.com/NiuTransServer/translationAlign";
            return await HttpHelper.PostAsync<TranslateAlignResponse>(url, Newtonsoft.Json.JsonConvert.SerializeObject(request));
        }
        /// <summary>
        /// 高级对照接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TranslateAlignResponse> TranslateAlignAsync(TranslateRequest request)
        {
            var url = "https://api.niutrans.com/NiuTransServer/translationAlign";
            return await HttpHelper.PostAsync<TranslateAlignResponse>(url, Newtonsoft.Json.JsonConvert.SerializeObject(request));
        }
    }
}
