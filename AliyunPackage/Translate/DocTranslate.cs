using AlibabaCloud.SDK.Alimt20181012.Models;
using AliyunPackage.Translate.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliyunPackage.Translate
{
    /// <summary>
    /// 文档翻译
    /// </summary>
    public class DocTranslate : ClientInit
    {
        public DocTranslate(string accessKeyId, string accessKeySecret) : base(accessKeyId, accessKeySecret, "mt")
        {
        }
        /// <summary>
        /// 创建文档翻译任务
        /// </summary>
        /// <param name="fileUrl">文档地址</param>
        /// <param name="sourceLanguage">原文语言</param>
        /// <param name="targetLanguage">译文语言</param>
        /// <param name="callbackUrl">回调url</param>
        /// <returns></returns>
        public async Task<CreateDocTranslateTaskResponse> CreateDocTranslateTaskAsync(string fileUrl, LanguageEnum sourceLanguage = LanguageEnum.中文, LanguageEnum targetLanguage = LanguageEnum.英语,string callbackUrl=null)
        {
            CreateDocTranslateTaskRequest createDocTranslateTaskRequest = new CreateDocTranslateTaskRequest()
            {
                FileUrl = fileUrl,
                SourceLanguage = sourceLanguage.GetDescription(),
                TargetLanguage = targetLanguage.GetDescription(),
                Scene = "general",
                CallbackUrl = callbackUrl
            };
            return await BaseClient.CreateDocTranslateTaskSimplyAsync(createDocTranslateTaskRequest);
        }
        /// <summary>
        /// 查询文档翻译任务
        /// </summary>
        /// <param name="taskId">任务id</param>
        /// <returns></returns>
        public async Task<GetDocTranslateTaskResponse> GetDocTranslateTaskAsync(string taskId)
        {
            GetDocTranslateTaskRequest getDocTranslateTaskRequest = new GetDocTranslateTaskRequest()
            {
                TaskId= taskId
            };
            return await BaseClient.GetDocTranslateTaskSimplyAsync(getDocTranslateTaskRequest);
        }

    }
}
