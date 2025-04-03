﻿using System;

namespace ecommerce.Models
{
    public class Merchants
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string WebsiteUrl { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
