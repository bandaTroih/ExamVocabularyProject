using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyProject
{
    delegate List<string> SearchWordHandler(string word);
    delegate List<string> GetAllWordsHandler(string language);
    delegate List<Tuple<string, string>> GetAllWordTranslationsHandler(string language, string word);
    delegate List<string> GetAllLanguagesHandler();
    delegate void SerializeHandler();

    interface IApplictionView
    {
        string NewWordText { get; }
        string NewWordLanguage { get; }
        List<Tuple<string, string>> NewWordTranslations { get; }

        event EventHandler AddNewWordButtonClick;
        event GetAllWordsHandler GetAllWordsFromLanguage;
        event GetAllLanguagesHandler GetAllLanguages;
        event SearchWordHandler SearchWord;
        event GetAllWordTranslationsHandler GetAllWordTranslations;
        event SerializeHandler Serialize;
        event SerializeHandler DeSerialize;

        List<string> SearchWordInvoker(string word);
        List<string> GetAllWordsInvoker(string language);
        List<string> GetAllLanguagesInvoker();
        List<Tuple<string, string>> GetAllWordTranslationsInvoker(string language, string word);
        void AddNewWordButtonClickInvoker(object sender, EventArgs e);
        void SerializeInvoker();
        void DeSerializeInvoker();

        void ShowError(string text);
        void Run();
    }
}
