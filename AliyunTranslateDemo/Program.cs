using AliyunPackage.Translate;
using AliyunTranslateDemo;
using AliyunTranslateDemo.Sample;
using System;
using System.Threading.Tasks;

namespace XiaoniuTranslate
{
    class Program
    {
        [STAThread]
        static async Task Main(string[] args)
        {
            //图像识别、翻译、文档之间转换（比如txt转word）、PDF可在线编辑、语音识别。
            ISample sample =
//new TranslateGeneralSample();//通用翻译
//new DocTranslateSample();//文档翻译
//new ImageTranslateSample();//图片翻译
//new ConvertOfficeSample();//文档转换
//new AudioFileTransSample();//语音识别
new NiuTranslateSample();//小牛翻译


            await sample.Run();
        }
    }
}
