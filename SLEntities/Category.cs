using System;
using System.Collections.Generic;
using System.Text;

namespace SLEntities
{
    public class Category : ModelBase<int>
    {
        string Label { get; set; }
    }
}
