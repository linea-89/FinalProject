using FinalProject.Shared.ModelInterfaces;
using FinalProject.Models.FloorModels;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models.MoveModels
{
    public class Move : IMove
    {
        [Key]
        public int Id { get; set; }
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

        // Explicit interface implementation
        ICollection<IAddress> IMove.Addresses
        {
            get => Addresses.Cast<IAddress>().ToList();
            set => Addresses = value.Cast<Address>().ToList();
        }

        IAmenities IMove.Amenities
        {
            get => Amenities;
            set => Amenities = (Amenities)value;
        }

        ICollection<IFloor> IMove.Floors
        {
            get => Floors.Cast<IFloor>().ToList();
            set => Floors = value.Cast<Floor>().ToList();
        }

    }
}
