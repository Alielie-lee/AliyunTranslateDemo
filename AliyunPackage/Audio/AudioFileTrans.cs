using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliyunPackage.Audio
{
    /// <summary>
    /// 音频转换
    /// </summary>
    public class AudioFileTrans
    {
        public DefaultAcsClient Client;
        // 地域ID，固定值。
        public const string REGIONID = "cn-shanghai";
        public const string PRODUCT = "nls-filetrans";
        public const string DOMAIN = "filetrans.cn-shanghai.aliyuncs.com";
        public const string API_VERSION = "2018-08-17";
        public const string POST_REQUEST_ACTION = "SubmitTask";
        public const string GET_REQUEST_ACTION = "GetTaskResult";
        // 请求参数
        public const string KEY_APP_KEY = "appkey";
        public const string KEY_FILE_LINK = "file_link";
        public const string KEY_VERSION = "version";
        public const string KEY_ENABLE_WORDS = "enable_words";
        // 响应参数
        public const string KEY_TASK = "Task";
        public const string KEY_TASK_ID = "TaskId";
        public const string KEY_STATUS_TEXT = "StatusText";
        // 状态值
        public const string STATUS_SUCCESS = "SUCCESS";
        public const string STATUS_RUNNING = "RUNNING";
        public const string STATUS_QUEUEING = "QUEUEING";
        public string AppKey;
        public AudioFileTrans(string accessKeyId, string accessKeySecret, string appKey = "xqBQDxmGDv46JkWG")
        {
            IClientProfile profile = DefaultProfile.GetProfile(REGIONID, accessKeyId, accessKeySecret);
            AppKey = appKey;
            Client = new DefaultAcsClient(profile);


        }
        /// <summary>
        /// 创建音频识别任务
        /// </summary>
        /// <param name="fileLink">音频地址</param>
        /// <returns></returns>
        public async Task<CommonResponse> CreateAudioFileTransTask(string fileLink)
        {
            try
            {
                /**
                 * 创建录音文件识别请求，设置请求参数。
                 */
                CommonRequest request = new CommonRequest();
                request.Domain = DOMAIN;
                request.Version = API_VERSION;
                request.Action = POST_REQUEST_ACTION;
                request.Product = PRODUCT;
                request.Method = MethodType.POST;
                // 设置task，以JSON字符串形式设置到请求Body中。
                JObject obj = new JObject();
                obj[KEY_APP_KEY] = AppKey;
                obj[KEY_FILE_LINK] = fileLink;
                // 新接入请使用4.0版本，已接入（默认2.0）如需维持现状，请注释掉该参数设置。
                obj[KEY_VERSION] = "4.0";
                // 设置是否输出词信息，默认为false。开启时需要设置version为4.0。
                obj[KEY_ENABLE_WORDS] = false;
                string task = obj.ToString();
                request.AddBodyParameters(KEY_TASK, task);
                return await new Task<CommonResponse>(() =>
                {
                    return Client.GetCommonResponse(request);
                });


            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (ClientException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取音频识别任务结果
        /// </summary>
        /// <param name="taskId">任务id</param>
        /// <returns></returns>
        public async Task<CommonResponse> GetAudioFileTransTask(string taskId)
        {
            try
            {
                CommonRequest getRequest = new CommonRequest();
                getRequest.Domain = DOMAIN;
                getRequest.Version = API_VERSION;
                getRequest.Action = GET_REQUEST_ACTION;
                getRequest.Product = PRODUCT;
                getRequest.Method = MethodType.GET;
                getRequest.AddQueryParameters(KEY_TASK_ID, taskId);
                return await new Task<CommonResponse>(() =>
                {
                    return Client.GetCommonResponse(getRequest);
                });

            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (ClientException ex)
            {
                throw ex;
            }
        }
    }
}
