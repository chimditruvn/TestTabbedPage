using System;
using System.Collections.Generic;
using System.Text;

namespace TopSell.Services
{
    public interface IClipboardService
    {
        void CopyToClipboard(string text);
    }
}
