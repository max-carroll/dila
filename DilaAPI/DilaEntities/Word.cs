using DilaShared.Dto;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Word
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Translation { get; set; }
        public WordType Type { get; set; }
        public string Emoji { get; set; }
        public Language Language { get; set; }
        public List<WordCategory> WordCategories { get; set; }

    }

    public class WordCategory
    {
        public int WordId { get; set; }
        public Word Word { get; set;}
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
