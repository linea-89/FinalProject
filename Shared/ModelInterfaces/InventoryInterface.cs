

namespace FinalProject.Shared.ModelInterfaces
{
    public interface IInventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Volume { get; set; }
        public bool Special { get; set; }
        public bool Disassemble { get; set; }
        public bool Assemble { get; set; }

        //  public File Image { get; set; }
        public IWrapping toBeWrapped { get; set; }
        public int RoomId { get; set; }
        public IRoom Room { get; set; }
        public bool NotIncluded { get; set; }
    }

    public interface IInventoryType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Volume { get; set; }
    }

    public interface IWrapping
    {
        public int Id { get; set; }
        public bool ShouldBeWrapped { get; set; }
        public string Note { get; set; }
        public int InventoryId { get; set; }
        public IInventory Inventory { get; set; }
    }
}
