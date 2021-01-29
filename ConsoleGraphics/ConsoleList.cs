using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public class ConsoleListElement : ConsoleObject, IIteratableElement
    {
        public IIteratable Parent { get; set; }
        

        public ConsoleColor SelectedColor { get; set; } = Config.SelectedColor;
        public bool Selected { get; set; }

        public event EventHandler OnClick;

        public void Click()
        {
            OnClick?.Invoke(this, new EventArgs());
        }

        public ConsoleListElement(ConsoleList parent) : this(parent, string.Empty, Config.DefaultColor)
        {
        }
        public ConsoleListElement(ConsoleList parent, ConsoleColor color) : this(parent, string.Empty, color)
        {
        }
        public ConsoleListElement(ConsoleList parent, string text) : this(parent, text, Config.DefaultColor)
        {
        }
        public ConsoleListElement(ConsoleList parent, string text, ConsoleColor color)
        {
            Parent = parent;
            Text = text;
            Color = color;
        }
        public override void Draw()
        {
            Console.Write("  ");
            if (Selected)
            {
                Console.Write(Config.SelectedPrefix);
                Console.ForegroundColor = SelectedColor;
                Console.WriteLine(Text);
            }
            else
                base.Draw();
            Console.ResetColor();
        }
    }

    public class ConsoleList : ConsoleObject, IIteratable
    {
        public List<ISelectableClickable> Elements { get; set; } = new List<ISelectableClickable>();

        public ConsoleList() : this(string.Empty, Config.DefaultColor)
        {
        }
        public ConsoleList(ConsoleColor color) : this(string.Empty, color)
        {
        }
        public ConsoleList(string text) : this(text, Config.DefaultColor)
        {
        }
        public ConsoleList(string text, ConsoleColor color)
        {
            Text = text;
            Color = color;
        }
        public override void Draw()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(Text);
            Console.ResetColor();
            foreach (var cli in Elements)
                cli.Draw();
        }

        public void ElementClicked(object elem)
        {
            (elem as ISelectableClickable).Click();
        }
    }
}
