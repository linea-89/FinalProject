

namespace FinalProject.Shared.ModelInterfaces
{
    public interface IRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FloorId { get; set; }
        public IFloor Floor { get; set; }

        public ICollection<IInventory> Inventories { get; }

    }
    public interface IRoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
