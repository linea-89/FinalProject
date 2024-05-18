using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Models.RoomModels
{
    public class RoomType : IRoomType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
