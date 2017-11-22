using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BBLInteface
{
    public interface IBotSetting
    {
        string Url { get; set; }

        string Name { get; set; }

        string Key { get; set; }
    }
}
