using AlibabaCloud.SDK.Alimt20181012.Models;
using AliyunPackage.Translate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
            Console.WriteLine(@"文档类型支持：txt、html、docx、pptx、xlsx。
文件大小最大：50M。
文件URL(FileUrl)访问权限需要为公开，URL中只能使用域名，不能使用IP地址，url中不可包含空格，请尽量避免使用中文。
结果回调URL(CallbackUrl)访问权限需要为公开，URL中只能使用域名，不能使用IP地址，URL中不可包含空格。
结果文件URL(TranslateFileUrl)有效性是1小时，查询文档翻译任务成功之后，需要在1小时内下载结果文件。");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("请输入需要翻译的文档地址：");
            var key = Console.ReadLine();
            var response = await client.CreateDocTranslateTaskAsync(key);
            Console.WriteLine("任务Id：" + response.TaskId);//5c32177513d94789a40c13cc97321427
            var flag = true;
            Console.WriteLine("-----------开始获取任务结果------------");
            while (flag)
            {
                Thread.Sleep(3000);//每3s获取一次结果
                var res = await GetResult(response.TaskId);
                //ready translating  translated  error
                if (res.Status == "ready")
                    Console.WriteLine("准备中...");
                if (res.Status == "translating")
                    Console.WriteLine("翻译中...");
                if (res.Status == "translated")
                {
                    flag = false;
                    Console.WriteLine("翻译完成！");
                    Console.WriteLine("文件地址：" + res.TranslateFileUrl);//有效性是1小时，查询文档翻译任务成功之后，需要在1小时内下载结果文件
                }
                if (res.Status == "error")
                {
                    flag = false;
                    Console.WriteLine("翻译出错");
                    Console.WriteLine("错误信息：" + res.TranslateErrorMessage);
                }
            }
        }
        /// <summary>
        /// 手动获取文档翻译结果
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public async Task<GetDocTranslateTaskResponse> GetResult(string taskid)
        {
            var response = await client.GetDocTranslateTaskAsync(taskid);
            return response;
        }
    }
}
