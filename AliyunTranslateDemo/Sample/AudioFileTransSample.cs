using AliyunPackage.Audio;
using AliyunPackage.Audio.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AliyunTranslateDemo.Sample
{
    /// <summary>
    /// 音频识别示例
    /// </summary>
    class AudioFileTransSample : ISample
    {
        AudioFileTrans client = new AudioFileTrans("accesskey", "accesssecret");
        public async Task Run()
        {
            Console.WriteLine("-----------音频识别示例------------");//http://www.luyin.com/upload/zhongxuejiaoyujingxinjiaoyu1223007rj.mp3
            Console.WriteLine("参数详情见 https://help.aliyun.com/document_detail/90727.html?spm=a2c4g.11186623.6.594.5783299crQ8gk0");
            Console.WriteLine("请输入音频地址");

            var url = Console.ReadLine();
            var response = await client.CreateAudioFileTransTaskAsync(url);

            //3eff3841606c11eb85920d0c632fc1d4
            Console.WriteLine("结果json：" + response.Data);
            var jsondata = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAudioFileTransTaskResponse>(response.Data); ;
            var flag = true;
            Console.WriteLine("-----------开始获取任务结果------------");
            while (flag)
            {
                Thread.Sleep(3000);//每3s获取一次结果
                var res = await GetResult(jsondata.TaskId);
                switch (res.StatusText)
                {
                    case "QUEUEING":
                        Console.WriteLine("排队中...");
                        break;
                    case "RUNNING":
                        Console.WriteLine("识别中...");
                        break;
                    case "SUCCEED":
                        flag = false;
                        Console.WriteLine("识别完成！");
                        foreach (var item in res.Sentences)
                        {
                            Console.WriteLine("识别结果：" + item.Text);
                        }
                        break;
                    default:
                        flag = false;
                        Console.WriteLine("转换出错");
                        Console.WriteLine("错误码：" + res.StatusCode);
                        Console.WriteLine("错误信息：" + res.StatusText);
                        break;
                }
            }
        }
        /// <summary>
        /// 获取转换任务结果
        /// </summary>
        public async Task<GetAudioFileTransTaskResponse> GetResult(string taskid)
        {
            var response = await client.GetAudioFileTransTaskAsync(taskid);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GetAudioFileTransTaskResponse>(response.Data);
        }
    }
}
