using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class PrivateMove
    {
        [Key]
        public int Id { get; set; }
        //public string Name { get; set; }
        //public int Phone { get; set; }
        //public string Email { get; set; }
        //public DateTime LoadingDate { get; set; }
        //public bool Packing { get; set; }
        //public DateTime? PackingDate { get; set; }
        //public DateTime UnloadingDate { get; set; }
        //public bool Unpacking { get; set; }
        //public DateTime? UnpackingDate { get; set; }
        public MoveAddress MovingAddresses { get; set; }
        //public Address AddressTo { get; set; }
        //public bool PackingPaper { get; set; }
        //public Amenities Amenities { get; set; }
    }


    [Owned]
    public class MoveAddress
    {
        public PrivateMove Move { get; set; }
        public Address From { get; set; }
        public Address To { get; set; }

    }

    [Owned]
    public class Address
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //  public int AddressId { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

}
