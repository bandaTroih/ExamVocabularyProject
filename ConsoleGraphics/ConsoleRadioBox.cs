using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGraphics
{
    public class ConsoleRadioBoxElement : ConsoleObject, IIteratableElement
    {
        public ConsoleColor SelectedColor { get; set; } = Config.SelectedColor;
        public bool Selected { get; set; }

        public bool Checked { get; set; }
        public IIteratable Parent { get; set; }

        public event EventHandler OnClick;

        public void Click()
        {
            OnClick?.Invoke(this, new EventArgs());
        }

        public ConsoleRadioBoxElement(ConsoleRadioBox parent) : this(parent, string.Empty, Config.DefaultColor)
        {
        }
        public ConsoleRadioBoxElement(ConsoleRadioBox parent, ConsoleColor color) : this(parent, string.Empty, color)
        {
        }
        public ConsoleRadioBoxElement(ConsoleRadioBox parent, string text) : this(parent, text, Config.DefaultColor)
        {
        }
        public ConsoleRadioBoxElement(ConsoleRadioBox parent, string text, ConsoleColor color)
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


    public class ConsoleRadioBox : ConsoleObject, IIteratable
    {
        public List<ISelectableClickable> Elements { get; set; } = new List<ISelectableClickable>();
        public ConsoleRadioBoxElement Checked 
        {
            get
            {
                return (ConsoleRadioBoxElement)Elements.Find(elem => (elem as ConsoleRadioBoxElement).Checked);
            }
        }
        public ConsoleRadioBox() : this(string.Empty, Config.DefaultColor)
        {
        }
        public ConsoleRadioBox(ConsoleColor color) : this(string.Empty, color)
        {
        }
        public ConsoleRadioBox(string text) : this(text, Config.DefaultColor)
        {
        }
        public ConsoleRadioBox(string text, ConsoleColor color)
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
            foreach (var e in Elements)
                (e as ConsoleRadioBoxElement).Checked = false;

            (elem as ConsoleRadioBoxElement).Checked = true;
            (elem as ConsoleRadioBoxElement).Click();
        }
    }
}
