using Newtonsoft.Json;
using System;

namespace SLEntities
{
    public class ModelBase<Identification>
    {
        public Identification Id { get; set; }

        public User CreateBy { get; set; }

        public User ModificationBy { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public bool IsValid { get; set; }
    }
}