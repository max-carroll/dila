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
        public IEnumerable<Category> Categories { get; set; }

    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
