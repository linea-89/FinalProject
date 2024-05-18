
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Shared.ModelInterfaces
{
    public interface IMove
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public int ContactPhone { get; set; }
        public string ContactEmail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LoadingDate { get; set; }
        public bool Packing { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PackingDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UnloadingDate { get; set; }
        public bool Unpacking { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UnpackingDate { get; set; }
        public bool PackingPaper { get; set; }
        // public Amenities Amenities { get; set; }
        public ICollection<IAddress> Addresses { get; set; }
        public IAmenities Amenities { get; set; }
        public ICollection<IFloor> Floors { get; set; }
    }
    public interface IAddress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }

        public int MoveId { get; set; }
        public IMove Move { get; set; }
    }

    public interface IAmenities
    {
        public int Id { get; set; }
        public bool ElevatorFromAddress { get; set; }
        public bool ElevatorToAddress { get; set; }
        public bool FurnitureLiftFromAddress { get; set; }
        public bool FurnitureLiftToAddress { get; set; }

        public int MoveId { get; set; }
        public IMove Move { get; set; }
    }

}
