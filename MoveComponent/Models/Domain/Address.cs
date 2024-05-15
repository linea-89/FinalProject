using FinalProject.Shared.Models.Domain;

namespace FinalProject.MoveComponent.Models.Domain
{
    public class Address
    {

        public int Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public int ZipCode { get; set; } = 0;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public int MoveId { get; set; }
        public Move Move { get; set; } = null!;

    }
}
