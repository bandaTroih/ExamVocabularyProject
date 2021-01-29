using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGraphics;
using Vocabulary;
using Vocabulary.Exceptions;

namespace VocabularyProject
{
    class Controller
    {
        private IApplictionView app;
        private Dictionary dictionary;
        private List<string> EnglishWords = new List<string>(){"ability","able", "about", "above", "accept", "according", "account", "across", "act", "action", "activity", "actually", "add", "address", "administration", "admit", "adult", "affect", "after", "again", "against", "age", "agency"};
        private List<string> RussianWords = new List<string>() {"способность", "способный", "о", "выше", "принять", "согласно", "аккаунт", "через", "действовать" , "действие", "активность", "на самом деле", "добавить", "адрес", "администрация", "принять", "взрослый", "аффект", "после", "снова", "против", "возраст ","агентство "};
        public Controller()
        {
            Init();
            app = new MainMenu();
            app.GetAllWordsFromLanguage += GetAllWords;
            app.GetAllLanguages += this.GetAllLanguages;
            app.AddNewWordButtonClick += App_AddNewWordButtonClick;
            app.Run();
        }

        private void App_AddNewWordButtonClick(object sender, EventArgs e)
        {
            var lng = dictionary.SearchLanguage(app.NewWordLanguage);
            lng.AddWord(app.NewWordText);
        }

        public void Init()
        {
            dictionary = new Dictionary();
            dictionary.AddLanguauge("English");
            dictionary.AddLanguauge("Russian");
            foreach (var w in EnglishWords)
                dictionary.Languages[0].AddWord(w);
            foreach (var w in RussianWords)
                dictionary.Languages[1].AddWord(w);
        }
        public List<string> GetAllWords(string language)
        {
            Language lng;
            try
            {
                lng = dictionary.SearchLanguage(language);
                return lng.GetAllWords();
            }
            catch(LanguageNotFound lnf)
            {
                app.ShowError(lnf.Message + "\nTry again!");
            }
            return new List<string>();
        }
        public List<string> GetAllLanguages()
        {
            return dictionary.GetAllLanguages();
        }
    }
}
