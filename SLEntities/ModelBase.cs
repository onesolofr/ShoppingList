using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLEntities
{
    public class ModelBase<Identification>
    {
        public Identification Id { get; set; }

        public string Content { get; set; }

        [NotMapped]
        public User CreateBy { get; set; }

        [NotMapped]
        public User ModificationBy { get; set; }

        [NotMapped]
        public DateTime CreationDate { get; set; }

        [NotMapped]
        public DateTime ModificationDate { get; set; }

        [NotMapped]
        public bool IsDeleted { get; set; }

        [JsonIgnore, NotMapped]
        public bool IsValid { get; set; }

        [JsonIgnore, NotMapped]
        public bool IsEditing { get; set; }
    }
}