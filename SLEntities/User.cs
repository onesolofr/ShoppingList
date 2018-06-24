using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SLEntities
{
    [Table("Users")]
    public class User : ModelBase<int>
    {
        public string Name { get; set; }

        [NotMapped]
        public string Login { get; set; }

        [NotMapped]
        public string Password { get; set; }

        [NotMapped]
        public string Email { get; set; }
    }
}
