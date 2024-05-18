

namespace FinalProject.Shared.ModelInterfaces
{
    public interface IFloor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public int MoveId { get; set; }
        public IMove Move { get; set; }

        public ICollection<IRoom> Rooms { get; set; }

    }

    public interface IFloorType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
