using NiuTranslate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AliyunTranslateDemo.Sample
{
    /// <summary>
    /// 小牛翻译示例
    /// </summary>
    class NiuTranslateSample : ISample
    {
        public async Task Run()
        {
            Console.WriteLine("-----------小牛翻译示例------------");
            var server = new TranslateServer();
            Console.WriteLine("请输入需要翻译的内容");
            var key = Console.ReadLine();
            var response = await server.TranslateFreeAsync(new NiuTranslate.Models.TranslateRequest
            {
                Apikey = "018647529f40e5395a5b91a614f96aba",
                Src_text = key,
                To = NiuTranslate.Enums.LanguageEnum.英语.GetDescription(),

            });
            if (response.Error_code == 0)
            {
                Console.WriteLine("翻译结果：" + response.Tgt_text);
            }
            else
                Console.WriteLine("翻译错误：" + response.Error_msg);

        }
    }
}
