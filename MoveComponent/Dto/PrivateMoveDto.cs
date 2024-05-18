using System.ComponentModel.DataAnnotations;

namespace FinalProject.MoveComponent.Dto
{
    public class PrivateMoveDto
    {
        public int Id { get; set; } = 0;
        public string Type { get; set; } = "PrivateMove";
        public string Name { get; set; } = string.Empty;
        public int Phone { get; set; } = 0;
        public string Email { get; set; } = string.Empty;

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
        public AddressDto MoveFromAddress { get; set; } = new AddressDto();
        public AddressDto MoveToAddress { get; set; } = new AddressDto();
        public AmenitiesDto Amenities { get; set; } = new AmenitiesDto();

    }
}
