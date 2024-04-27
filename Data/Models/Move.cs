using System;


namespace FinalProject.Data.Models
{
    public class Move
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Phone { get; set; }
        public string? Email { get; set; }
        public DateTime LoadingDate { get; set; }
        public bool Packing { get; set; }
        public DateTime? PackingDate { get; set; }
        public DateTime UnloadingDate { get; set; }
        public bool Unpacking { get; set; }
        public DateTime? UnpackingDate { get; set; }
    }
}
