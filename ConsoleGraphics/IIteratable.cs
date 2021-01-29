using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public interface IIteratable
    {
        List<ISelectableClickable> Elements { get; set; }
        void ElementClicked(object elem);
    }
}
