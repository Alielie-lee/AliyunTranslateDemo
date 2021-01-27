using AliyunPackage.Translate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliyunTranslateDemo.Sample
{
    /// <summary>
    /// 文档翻译示例
    /// </summary>
    class DocTranslateSample : ISample
    {
        DocTranslate client = new DocTranslate("LTAI4FhcggVQT1JzUtjA8CDS", "zZHER19KvQx5DP0dllwcK2HWDyBYgg");
        public async Task Run()
        {
            Console.WriteLine("-----------文档翻译示例------------");
            Console.WriteLine("请输入需要翻译的文档地址");
            var key = Console.ReadLine();
            var response = await client.CreateDocTranslateTaskAsync(key);
            Console.WriteLine("任务Id：" + response.TaskId);

        }
        /// <summary>
        /// 获取文档翻译结果
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public async Task<string> GetResult(string taskid)
        {
            var response = await client.GetDocTranslateTaskAsync(taskid);
            return response.TranslateFileUrl;
        }
    }
}
