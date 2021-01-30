using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VocabularyProject.Views;

namespace VocabularyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            Controller controller = new Controller(mainMenu);
        }
    }
}
