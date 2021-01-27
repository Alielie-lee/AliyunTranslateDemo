using AliyunPackage.Audio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliyunTranslateDemo.Sample
{
    /// <summary>
    /// 音频识别示例
    /// </summary>
    class AudioFileTransSample : ISample
    {
        AudioFileTrans client = new AudioFileTrans("LTAI4FhcggVQT1JzUtjA8CDS", "zZHER19KvQx5DP0dllwcK2HWDyBYgg");
        public async Task Run()
        {
            Console.WriteLine("-----------音频识别示例------------");
            Console.WriteLine("请输入音频地址");
            var url = Console.ReadLine();
            var response = await client.CreateAudioFileTransTaskAsync(url);
            Console.WriteLine("结果json：" + response.Data);
        }
        /// <summary>
        /// 获取转换任务结果
        /// </summary>
        public async Task<string> GetResult(string taskid)
        {
            var response = await client.GetAudioFileTransTaskAsync(taskid);
            return response.Data;
        }
    }
}
