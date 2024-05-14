using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using FinalProject.FloorComponent.Models.Domain;

namespace FinalProject.MoveComponent.Models.Domain
{
    public class Move
    {
        [Key]
        public int Id { get; set; } = 0;
        public string Type { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Phone { get; set; } = 0;
        public string Email { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public int ContactPhone { get; set; } = 0;
        public string ContactEmail { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LoadingDate { get; set; }
        public bool Packing { get; set; } = false;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PackingDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UnloadingDate { get; set; }
        public bool Unpacking { get; set; } = false;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UnpackingDate { get; set; }

        public bool PackingPaper { get; set; } = false;
        // public Amenities Amenities { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public Amenities Amenities { get; set; } = null!;

        public ICollection<Floor> Floors { get; set; } = new List<Floor>();
    }
}
