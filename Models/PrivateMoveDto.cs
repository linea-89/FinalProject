using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class PrivateMoveDto
    {
       // public int Id { get; set; }
        public string? Name { get; set; }
        //public int Phone { get; set; }
        //public string Email { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime LoadingDate { get; set; }
        //public bool Packing { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? PackingDate { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime UnloadingDate { get; set; }
        //public bool Unpacking { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? UnpackingDate { get; set; }
        //public bool PackingPaper { get; set; }
        public AddressDto MoveFromAddress { get; set; } = new AddressDto();
        public AddressDto MoveToAddress { get; set; } = new AddressDto();

    }

    //public class AddressDto
    //{
    //    public string Street { get; set; } = string.Empty;
    //    //public int ZipCode { get; set; } = 0;
    //    //public string City { get; set; } = string.Empty;
    //    //public string Country { get; set; } = string.Empty;
    //    public string Type {  get; set; } = string.Empty;
    //}

}
