using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Models.MoveModels
{
    public class Address : IAddress
    {

        public int Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public int ZipCode { get; set; } = 0;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public int MoveId { get; set; }
        public Move Move { get; set; } = null!;

        IMove IAddress.Move
        {
            get => Move;
            set => Move = (Move)value;
        }

    }

}
