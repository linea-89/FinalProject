namespace FinalProject.Models
{
    public class Floor
    { 
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;

        public int MoveId { get; set; } // Required foreign key property
        public Move Move { get; set; } = null!; // Required reference navigation to principal
    }
}
