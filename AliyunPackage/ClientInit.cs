using AlibabaCloud.RPCClient.Models;
using AlibabaCloud.SDK.Alimt20181012;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using System;

namespace AliyunPackage
{
    /// <summary>
    /// Aliyun请求初始化
    /// </summary>
    public class ClientInit
    {
#if true
        #region 新版SDK
        public Client BaseClient;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="accessKeyId">accessKeyId</param>
        /// <param name="accessKeySecret">accessKeySecret</param>
        /// <param name="endpointPrefix">请求域名前缀</param>
        public ClientInit(string accessKeyId, string accessKeySecret, string endpointPrefix, string region = "cn-hangzhou")
        {
            BaseClient = new Client(new Config
            {
                AccessKeyId = accessKeyId,
                AccessKeySecret = accessKeySecret,
                Endpoint = endpointPrefix + "." + region + ".aliyuncs.com"
            });
        }
        #endregion
#else
        #region 旧版SDK

        public DefaultAcsClient BaseClient;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="accessKeyId"></param>
        /// <param name="accessKeySecret"></param>
        /// <param name="region"></param>
        public ClientInit(string accessKeyId, string accessKeySecret, string region = "cn-hangzhou")
        {
            IClientProfile profile = DefaultProfile.GetProfile(region, accessKeyId, accessKeySecret);
            BaseClient = new DefaultAcsClient(profile);
        }
        #endregion
#endif
    }
}
