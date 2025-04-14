﻿using System;

namespace Group_Project.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int StockQuantity { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
