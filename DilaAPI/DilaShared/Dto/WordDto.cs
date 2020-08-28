using System;
using System.Collections.Generic;
using System.Text;

namespace DilaShared.Dto
{

    public enum Language
    {
        English,
        Tagalog
    }

    public enum WordType
    {
        Noun,
        Verb,
        Adjective,
        Adverb,
        Pronoun
    }

    public class WordDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Translation { get; set; }
        public WordType Type { get; set; }
        public string Emoji { get; set; }
        public Language Language { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}

