﻿using System.Reflection.Metadata;

namespace FinalProject.Models
{
    public class Amenities
    {
        public int Id { get; set; } = 0;
        public bool ElevatorFromAddress { get; set; } = false;
        public bool ElevatorToAddress { get; set; } = false;
        public bool FurnitureLiftFromAddress { get; set; } = false;
        public bool FurnitureLiftToAddress { get; set; } = false;

        public int PrivateMoveId { get; set; } // Required foreign key property
        public PrivateMove PrivateMove { get; set; } = null!; // Required reference navigation to principal
    }
}