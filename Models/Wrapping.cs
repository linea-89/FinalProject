﻿namespace FinalProject.Models
{
    public class Wrapping
    {
        public int Id { get; set; }
        public bool ShouldBeWrapped { get; set; } = false;
        public string Note { get; set; } = string.Empty;
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; } = null!;
    }
}
