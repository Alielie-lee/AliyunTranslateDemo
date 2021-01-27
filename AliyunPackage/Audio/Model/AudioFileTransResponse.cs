using Aliyun.Acs.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliyunPackage.Audio.Model
{
    /// <summary>
    /// 语音识别返回参数
    /// </summary>
    public class GetAudioFileTransTaskResponse
    {
        public string TaskId { get; set; }
        public string RequestId { get; set; }
        public string StatusText { get; set; }
        public long BizDuration { get; set; }
        public long SolveTime { get; set; }
        public int StatusCode { get; set; }
        public List<Sentences> Sentences { get; set; }
        public List<Words> Words { get; set; }
        
    }
    /// <summary>
    /// 词信息，获取时需设置enable_words为true，且设置服务version为”4.0”。
    /// </summary>
    public class Words
    {
        public int ChannelId { get; set; }
        public string Word { get; set; }
        public int BeginTime { get; set; }
        public int EndTime { get; set; }
    }
    /// <summary>
    /// 识别的结果数据。当StatuxText为SUCCEED时存在。
    /// </summary>
    public class Sentences
    {
        public int SilenceDuration { get; set; }
        public int EmotionValue { get; set; }
        public int ChannelId { get; set; }
        public string Text { get; set; }
        public int BeginTime { get; set; }
        public int EndTime { get; set; }
        public int SpeechRate { get; set; }
    }
}
