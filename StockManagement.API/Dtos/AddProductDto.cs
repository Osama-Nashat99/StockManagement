﻿namespace StockManagement.API.Dtos
{
    public class AddProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
