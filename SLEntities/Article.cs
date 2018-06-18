using System;
using System.Collections.Generic;
using System.Text;

namespace SLEntities
{
    public class Article : ModelBase<int>
    {
        public string Label { get; set; }

        public int Quantity { get; set; }

        public int Priority { get; set; }

        public Category ArticleCategory { get; set; }

        public Detail ArticleDetail { get; set; }

        public Unit ArticleUnit { get; set; }
    }
}
