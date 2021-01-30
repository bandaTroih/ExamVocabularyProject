using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocabulary;
using VocabularyProject.Views;

namespace VocabularyProject
{
    class Program
    {
        #region Json Test

        class JsonTest
        {
            private Dictionary dictionary;

            private List<string> EnglishWords =
                new List<string>() { "ability", "able", "about", "above", "accept", "according", "account", "across", "act", "action", "activity", "actually", "add", "address", "administration", "admit", "adult", "affect", "after", "again", "against", "age", "agency" };

            private List<string> RussianWords =
                new List<string>() { "способность", "способный", "о", "выше", "принять", "согласно", "аккаунт", "через", "действовать", "действие", "активность", "на самом деле", "добавить", "адрес", "администрация", "принять", "взрослый", "аффект", "после", "снова", "против", "возраст ", "агентство " };

            public void Init()
            {
                dictionary = new Dictionary();
                dictionary.AddLanguage("English");
                dictionary.AddLanguage("Russian");
                foreach (var w in EnglishWords)
                    dictionary.Languages[0].AddWord(w);
                foreach (var w in RussianWords)
                    dictionary.Languages[1].AddWord(w);
                for (int i = 0; i < EnglishWords.Count(); i++)
                    dictionary.AddTranslation(1, i + 1, 2, i + 1);

                JsonManager json = new JsonManager(dictionary);
                json.SaveData();

                dictionary = null;
                Console.WriteLine("dictionary clear");

                dictionary = json.LoadData();

                Console.WriteLine("dictionary loaded !\n");
                var dic = dictionary.GetAllLanguages();

                foreach (var t in dic)
                {
                    Console.WriteLine(t);
                }
            }
        }
        

        #endregion
        

        static void Main(string[] args)
        {
            //JsonTest test = new JsonTest();
            //test.Init();

            MainMenu mainMenu = new MainMenu();
            Controller controller = new Controller(mainMenu);
        }
    }
}
