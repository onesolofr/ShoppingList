using System;
using System.Collections.Generic;
using System.Text;

namespace SLEntities
{
    public class User : ModelBase<int>
    {
        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
