﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Vocabulary.Exceptions;

namespace Vocabulary
{
    public class Language : IEntity
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public List<Word> Words { get; set; } = new List<Word>();

        public Language()
        { }

        public Language(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Word SearchWord(string word)
        {
            Word wd = Words.Find(l => l.Name.ToLower() == word.ToLower());
            if (wd is null)
                throw new WordNotFound($"Word {word} not found");
            return wd;
        }
        public Word SearchWord(int Id)
        {
            Word wd = Words.Find(l => l.Id == Id);
            if (wd is null)
                throw new WordNotFound($"Word {Id} not found");
            return wd;
        }


        public void AddWord(string word)
        {
            try
            {
                SearchWord(word);
            }
            catch
            {
                Words.Add(new Word(Methods.GetLastElementId((IEnumerable<IEntity>)Words)+1, word.ToLower(), Id));
            }
        }
        public List<string> GetAllWords()
        {
            var wds = Words.Select(w => w.Name).ToList();
            return wds;
        }
    }
}