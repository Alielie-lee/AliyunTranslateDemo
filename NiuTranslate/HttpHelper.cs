using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NiuTranslate
{
    public static class HttpHelper
    {
        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="url">地址</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public async static Task<T> PostAsync<T>(string url, string param)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = HttpMethod.Post.ToString();
            req.ContentType = "application/json";
            #region 添加Post 参数
            byte[] data = Encoding.UTF8.GetBytes(param);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                await reqStream.WriteAsync(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = null;
            try
            {
                resp = (HttpWebResponse)await req.GetResponseAsync();
            }
            catch (WebException ex)
            {
                resp = (HttpWebResponse)ex.Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = await reader.ReadToEndAsync();
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">地址</param>
        /// <returns></returns>
        public async static Task<T> GetAsync<T>(string url)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = HttpMethod.Post.ToString();

            HttpWebResponse resp = null;
            try
            {
                resp = (HttpWebResponse)await req.GetResponseAsync();
            }
            catch (WebException ex)
            {
                resp = (HttpWebResponse)ex.Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = await reader.ReadToEndAsync();
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
        }
    }
}
