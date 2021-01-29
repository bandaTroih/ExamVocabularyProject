using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleGraphics
{
    public class ConsoleView
    {
        public string Title
        {
            get => Console.Title;
            set => Console.Title = value;
        }
        public event EventHandler OnStart;
        public event EventHandler OnStop;
        //public event EventHandler OnButtonClick;
        public List<ConsoleObject> Controls { get; set; } = new List<ConsoleObject>();
        private List<ISelectableClickable> SelectableControls
        {
            get {
                List<ISelectableClickable> selectableControls = new List<ISelectableClickable>();
                foreach(var c in Controls)
                {
                    if (c is IIteratable)
                        selectableControls.AddRange((c as IIteratable).Elements);
                    else if (c is ISelectable)
                        selectableControls.Add((ISelectableClickable)c);
                }
                return selectableControls;
            }
        }
        public bool Runing { get; set; }
        public ConsoleView()
        {
            
        }

        public ConsoleView(List<ConsoleObject> objects)
        {
            Controls = objects;
        }

        private void Draw()
        {
            foreach (var CO in Controls)
                CO.Draw();
        }

        public void Run()
        {
            Runing = true;
            InitialSelect();
            OnStart?.Invoke(this, new EventArgs());
            while (Runing)
            {
                Console.Clear();
                Draw();
                ConsoleKeyInfo key = Console.ReadKey(true);
                ButtonClicked(key);
            }
            OnStop?.Invoke(this, new EventArgs());
        }

        private void ButtonClicked(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    SelectNext();
                    break;
                case ConsoleKey.UpArrow:
                    SelectPrev();
                    break;
                case ConsoleKey.Enter:
                    ClickSelected();
                    break;
            }
        }

        private void ClickSelected()
        {
            if (SelectableControls.Count == 0) return;
            var elem = SelectableControls.Find((obj)
                => obj.Selected);
            if (elem is IIteratableElement)
                (elem as IIteratableElement).Parent.ElementClicked(elem);
            else
                elem.Click();
        }

        private void InitialSelect()
        {
            if (SelectableControls.Count == 0) return;
            var elem = SelectableControls.Find((obj)
                => obj.Selected);

            if (elem is null)
                (SelectableControls[0] as ISelectable).Selected = true;
        }

        private void SelectNext()
        {
            if (SelectableControls.Count == 0) return;
            
            
            for (int i = 0; i < SelectableControls.Count; i++)
            {
                if (i + 1 == SelectableControls.Count)
                    return;
                else if(SelectableControls[i].Selected)
                {
                    SelectableControls[i].Selected = false;
                    SelectableControls[i+1].Selected = true;
                    return;
                }
            }
        }

        private void SelectPrev()
        {
            if (SelectableControls.Count == 0) return;
            
            
            for (int i = SelectableControls.Count-1; i >= 0; i--)
            {
                if (i == 0)
                    return;
                else if(SelectableControls[i].Selected)
                {
                    SelectableControls[i].Selected = false;
                    SelectableControls[i - 1].Selected = true;
                    return;
                }
            }
        }
    }
}
