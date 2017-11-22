using Application.BBLInteface;
using System;
namespace Application.BBL
{
    public sealed class BotSetting :IBotSetting
    {
        public string Url { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }       
    }
}
