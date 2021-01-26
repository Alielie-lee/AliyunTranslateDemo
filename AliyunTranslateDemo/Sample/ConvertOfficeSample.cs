using AliyunPackage.Office;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliyunTranslateDemo.Sample
{
    /// <summary>
    /// 文档转换示例
    /// </summary>
    class ConvertOfficeSample : ISample
    {
        ConvertOffice client = new ConvertOffice("LTAI4FhcggVQT1JzUtjA8CDS", "zZHER19KvQx5DP0dllwcK2HWDyBYgg");
        public async Task Run()
        {
            Console.WriteLine("-----------文档转换示例------------");
            Console.WriteLine("请输入任务名称");
            var name = Console.ReadLine();
            Console.WriteLine("请输入源数据的OSS存储位置");
            var srcUri = Console.ReadLine();
            Console.WriteLine("请输入转换后输出内容的目标OSS位置");
            var tgtUri = Console.ReadLine();
            var response = await client.CreateOfficeConversionTask(name, srcUri, tgtUri, "pdf");
            Console.WriteLine("TaskId：" + response.TaskId);
        }
        /// <summary>
        /// 获取转换任务结果
        /// </summary>
        public async Task<string> GetResult(string taskid, string name)
        {
            var response = await client.GetOfficeConversionTask(name, taskid);
            return response.TgtUri;
        }
    }
}
