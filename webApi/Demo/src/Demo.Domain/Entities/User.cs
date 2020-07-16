using Demo.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Demo.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(FieldSizes.Name)]
        public string FirstName { get; set; }

        [Required, MaxLength(FieldSizes.Name)]
        public string LastName { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
