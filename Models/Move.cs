using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace FinalProject.Models
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
        public string ContactPerson { get; set;} = string.Empty;
        public int ContactPhone { get; set; } = 0;
        public string ContactEmail { get; set;} = string.Empty;

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
        public Amenities Amenities { get; set; } = new Amenities();

        public ICollection<Floor> Floors { get; set; } = new List<Floor>();
    }


    //[Owned]
    //public class MoveAddress
    //{
    //    public PrivateMove Move { get; set; }
    //    public Address From { get; set; }
    //    public Address To { get; set; }

    //}

    //[Owned]
    //public class Address
    //{
    //    public string Street { get; set; }
    //    public int ZipCode { get; set; }
    //    public string City { get; set; }
    //    public string Country { get; set; }
    //}

    //[Owned]
    //public class Amenities
    //{
    //    public PrivateMove Move { get; set; }
    //    public Elevator Elevator { get; set; }
    //    public FurnitureLift FurnitureLift { get; set; }
    //}

    //[Owned]
    //public class Elevator
    //{
    //    public bool FromAddress { get; set; }
    //    public bool ToAddress { get; set; }
    //}

    //[Owned]
    //public class FurnitureLift
    //{
    //    public bool FromAddress { get; set; }
    //    public bool ToAddress { get; set; }
    //}

}
