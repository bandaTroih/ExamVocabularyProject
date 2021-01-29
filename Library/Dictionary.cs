using System;
using System.Collections.Generic;
using System.Linq;
using Vocabulary.Exceptions;

namespace Vocabulary
{
   
    public class Dictionary
    {
        public string  Name { get; set; }
        public List<Language> Languages { get; set; } = new List<Language>();
        public List<Translation> Translations { get; set; } = new List<Translation>();
        public Dictionary()
        {

        }


        public Language SearchLanguage(string language)
        {
            Language lng = Languages.Find(l => l.Name.ToLower() == language.ToLower());
            if (lng is null)
                throw new LanguageNotFound($"Language {language} not found");
            return lng;
        }
        public Language SearchLanguage(int Id)
        {
            Language lng = Languages.Find(l => l.Id == Id);
            if (lng is null)
                throw new LanguageNotFound($"Language {Id} not found");
            return lng;
        }

        //public Translation SearchTranslation(string language)
        //{
        //    Language lng = Languages.Find(l => l.Name.ToLower() == language.ToLower());
        //    if (lng is null)
        //        throw new LanguageNotFound($"Language {language} not found");
        //    return lng;
        //}
        public Translation SearchTranslation(int language1Id, int word1Id, int language2Id, int word2Id)
        {
            Translation tr = Translations.Find(t => t.Language1Id == language1Id && t.Word1Id == word1Id && t.Language2Id == language2Id && t.Word2Id == word2Id);
            if (tr is null)
                throw new TranslationNotFound($"Translation {language1Id} {word1Id} {language2Id} {word2Id} not found");
            return tr;
        }

        public void AddLanguauge(string language)
        {
            try
            {
                SearchLanguage(language);
            }
            catch(LanguageNotFound)
            { 
                Languages.Add(new Language(Methods.GetLastElementId((IEnumerable<IEntity>)Languages) + 1, language));
            }
        }

        public List<string> GetAllLanguages()
        {
            var lngs = Languages.Select(w => w.Name).ToList();
            return lngs;
        }
        public void AddTranslation(int language1Id, int word1Id, int language2Id, int word2Id)
        {
            try
            {
                SearchTranslation(language1Id, word1Id, language2Id, word2Id);
            }
            catch (TranslationNotFound)
            {
                Translations.Add(new Translation() { Id = Methods.GetLastElementId((IEnumerable<IEntity>)Translations) + 1 });
            }
        }
        List<Word> SearchTranslations(string language, string word)
        {
            Language lng;
            try
            {
                lng = SearchLanguage(language);
            }
            catch(LanguageNotFound)
            {
                throw;
            }
            Word wd;
            try
            {
                wd = lng.SearchWord(word);
            }
            catch (WordNotFound)
            {
                throw;
            }

            var trnsls = Translations.FindAll(t => t.Language1Id == lng.Id && t.Word1Id == wd.Id);
            Translations.FindAll(t => t.Language2Id == lng.Id && t.Word2Id == wd.Id).ForEach(t =>
            {
                int tmp = t.Language1Id;
                t.Language1Id = t.Language2Id;
                t.Language2Id = tmp;
                tmp = t.Word1Id;
                t.Word1Id = t.Word2Id;
                t.Word2Id = tmp;
                trnsls.Add(t);
            });
            return new List<Word>();
            //var res
            //return lng.Words.Join()
        }
        //public void AddWord(string word, int languageId, List<int> translationsIds)
        //{
        //    int lastId = GetLastElementId((IEnumerable<IEntity>)Words);
        //    var CheckWd = SearchWord(word, languageId);
        //    var ChekLng = Languages.Find(l => l.Id == languageId);
        //    if (CheckWd is null && !(ChekLng is null))
        //    {
        //        Word wd = new Word() { Id = lastId + 1, Name = word, LanguageId = languageId };
        //        Words.Add(wd);
        //    }
        //    else if (ChekLng is null)
        //        throw new LanguageNotFound($"Language {languageId} not found");
        //}
    }
}
