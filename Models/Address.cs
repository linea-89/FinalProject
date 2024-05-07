﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace FinalProject.Models
{
    public class Address
    {

        public int Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public int ZipCode { get; set; } = 0;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        //public string Type { get; set; }
        [NotMapped]
        public int PrivateMoveId { get; set; } // Required foreign key property
        [NotMapped]
        public PrivateMove PrivateMove { get; set; } = null!; // Required reference navigation to principal

    }
}
