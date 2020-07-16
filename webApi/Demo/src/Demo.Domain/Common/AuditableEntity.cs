using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Demo.Domain.Common
{
    public class AuditableEntity
    {
        [JsonIgnore]
        public string CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime Created { get; set; }

        [JsonIgnore]
        public string LastModifiedBy { get; set; }

        [JsonIgnore]
        public DateTime? LastModified { get; set; }
    }
}
