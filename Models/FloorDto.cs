﻿namespace FinalProject.Models
{
    public class FloorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;
        public int MoveId { get; set; }
    }
}
