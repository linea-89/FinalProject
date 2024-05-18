using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Models.FloorModels
{
    public class FloorType : IFloorType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

}
