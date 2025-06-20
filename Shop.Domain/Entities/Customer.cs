﻿using System.Text.Json.Serialization;

namespace Shop.Domain.Entities
{
    public class Customer
    {       
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
