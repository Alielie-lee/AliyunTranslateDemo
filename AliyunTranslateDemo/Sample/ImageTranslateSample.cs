using AliyunPackage.Translate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliyunTranslateDemo.Sample
{
    /// <summary>
    /// 图片翻译示例
    /// </summary>
    class ImageTranslateSample : ISample
    {
        public async Task Run()
        {
            Console.WriteLine("-----------图片翻译示例------------");
            var client = new ImageTranslate("accesskey", "accesssecret");
            Console.WriteLine("请输入需要翻译的图片地址");
            //https://gimg2.baidu.com/image_search/src=http%3A%2F%2Fimg3.duitang.com%2Fuploads%2Fitem%2F201607%2F30%2F20160730101724_BR2tP.thumb.700_0.jpeg&refer=http%3A%2F%2Fimg3.duitang.com&app=2002&size=f9999,10000&q=a80&n=0&g=0n&fmt=jpeg?sec=1614152947&t=e61b35e0423b1f70e356e33514510df3
            var key = Console.ReadLine();
            var response = await client.GetImageTranslateAsync(key);
            if (response.Code == 200)
            {
                Console.WriteLine("翻译结果：");
                Console.WriteLine("ORC:"+response.Data.Orc);
                Console.WriteLine("PictureEditor:" + response.Data.PictureEditor);
                Console.WriteLine("Url:" + response.Data.Url);
            }
            else
                Console.WriteLine("翻译错误：" + response.Message);

        }
    }
}
