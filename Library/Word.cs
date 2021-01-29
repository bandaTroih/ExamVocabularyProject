using System;
using System.Collections.Generic;
using System.Text;

namespace Vocabulary
{
    public class Word : IEntity
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public int LanguageId { get; set; } = 0;

        public Word()
        { }
        public Word(int id, string word, int languageId)
        {
            Id = id;
            Name = word;
            LanguageId = languageId;
        }
    }
}
