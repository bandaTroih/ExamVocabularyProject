using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public interface ISelectable
    {
        ConsoleColor SelectedColor { get; set; }
        bool Selected { get; set; }
    }
}
