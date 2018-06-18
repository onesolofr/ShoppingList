using System;
using System.Collections.Generic;
using System.Text;

namespace SLEntities
{
    public class ShoppingList : ModelBase<int>
    {
        public string Label { get; set; }

        public IList<Article> Articles { get; set; }
    }
}