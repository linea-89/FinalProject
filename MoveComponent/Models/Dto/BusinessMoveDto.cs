using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.MoveComponent.Models.Dto
{
    public class BusinessMoveDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = "BusinessMove";
        public string CompanyName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public int ContactPhone { get; set; } = 0;
        public string ContactEmail { get; set; } = string.Empty;

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
        public AddressDto MoveFromAddress { get; set; } = new AddressDto();
        public AddressDto MoveToAddress { get; set; } = new AddressDto();
        public AmenitiesDto Amenities { get; set; } = new AmenitiesDto();

    }
}
