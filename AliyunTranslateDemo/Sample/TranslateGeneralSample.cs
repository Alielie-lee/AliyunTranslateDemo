using AliyunPackage.Translate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliyunTranslateDemo.Sample
{
    /// <summary>
    /// 通用翻译示例
    /// </summary>
    class TranslateGeneralSample : ISample
    {
        public async Task Run()
        {
            Console.WriteLine("-----------通用翻译示例------------");
            var client = new Translate("LTAI4FhcggVQT1JzUtjA8CDS", "zZHER19KvQx5DP0dllwcK2HWDyBYgg");
            Console.WriteLine("请输入需要翻译的内容");
            var key = Console.ReadLine();
            var response = await client.TranslateGeneral(key);
            if (response.Code == 200)
                Console.WriteLine("翻译结果：" + response.Data.Translated);
            else
                Console.WriteLine("翻译错误：" + response.Message);

        }
    }
}
