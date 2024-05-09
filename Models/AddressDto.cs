namespace FinalProject.Models
{
    public class AddressDto
    {
        public string Street { get; set; } = string.Empty;
        public int ZipCode { get; set; } = 0;
        //public string City { get; set; } = string.Empty;
        //public string Country { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
