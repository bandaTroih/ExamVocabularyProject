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
        JsonManager Serializer;
        public Controller(IApplictionView view)
        {
            Serializer = new JsonManager(dictionary);
            app = view;
            app.GetAllWordsFromLanguage += GetAllWords;
            app.GetAllLanguages += this.GetAllLanguages;
            app.AddNewWordButtonClick += AddNewWord;
            app.Serialize += Serialize;
            app.DeSerialize += DeSerialize;
            app.GetAllWordTranslations += GetAllWordTranslations;
            app.Run();
        }

        private void DeSerialize()
        {
            dictionary = Serializer.LoadData();
        }

        private void Serialize()
        {
            Serializer.SaveData();
        }

        private List<Tuple<string, string>> GetAllWordTranslations(string language, string word)
        {
            var wds = dictionary.SearchTranslations(language, word);//.Select(w => w.Name).ToList();
            List<Tuple<string, string>> lt = new List<Tuple<string, string>>();
            foreach (var wd in wds)
                lt.Add(new Tuple<string, string>(dictionary.SearchLanguage(wd.LanguageId).Name, wd.Name));
            return lt;
        }

        private void AddNewWord(object sender, EventArgs e)
        {
            if (app.NewWordText == string.Empty)
                app.ShowError("New word is empty");
            else
            {
                var lng = dictionary.SearchLanguage(app.NewWordLanguage);
                lng.AddWord(app.NewWordText);
            }
            foreach (var t in app.NewWordTranslations)
                dictionary.AddTranslation(app.NewWordLanguage, app.NewWordText, t.Item1, t.Item2);
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
