using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public interface IIteratableElement : ISelectableClickable
    {
        IIteratable Parent { get; set; }
    }
}
