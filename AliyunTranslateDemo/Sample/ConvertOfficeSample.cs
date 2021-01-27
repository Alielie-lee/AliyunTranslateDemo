using Aliyun.Acs.imm.Model.V20170906;
using AliyunPackage.Office;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AliyunTranslateDemo.Sample
{
    /// <summary>
    /// 文档转换示例
    /// </summary>
    class ConvertOfficeSample : ISample
    {
        ConvertOffice client = new ConvertOffice("LTAI4FhcggVQT1JzUtjA8CDS", "zZHER19KvQx5DP0dllwcK2HWDyBYgg", "cn-shanghai");
        public async Task Run()
        {
            Console.WriteLine("-----------文档转换示例------------");
            Console.WriteLine("注：需要转换的oss文件必须和本项目开通的地区一致，如都是 “cn-shanghai”");
            var response = await client.CreateOfficeConversionTaskAsync("testproject", "oss://wisdom-lisj/test.txt", "oss://wisdom-lisj/imm-format-convert-tgt", "pdf");
            Console.WriteLine("TaskId：" + response.TaskId);

            var flag = true;
            Console.WriteLine("-----------开始获取任务结果------------");
            while (flag)
            {
                Thread.Sleep(3000);//每3s获取一次结果
                var res = await GetResult(response.TaskId, "testproject");
                if (res.Status == "Running")
                    Console.WriteLine("转换中...");
                if (res.Status == "Finished")
                {
                    flag = false;
                    Console.WriteLine("转换完成！");
                    Console.WriteLine("文件地址：" + res.TgtUri);
                }
                if (res.Status == "Failed")
                {
                    flag = false;
                    Console.WriteLine("转换出错");
                    Console.WriteLine("错误信息：" + res.FailDetail.Code);
                }
            }
        }
        /// <summary>
        /// 获取转换任务结果
        /// </summary>
        public async Task<GetOfficeConversionTaskResponse> GetResult(string taskid, string name)
        {
            return await client.GetOfficeConversionTaskAsync(name, taskid);
        }
    }
}
