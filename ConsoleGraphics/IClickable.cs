using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public interface IClickable
    {
        void Click();
        event EventHandler OnClick;
    }
}
