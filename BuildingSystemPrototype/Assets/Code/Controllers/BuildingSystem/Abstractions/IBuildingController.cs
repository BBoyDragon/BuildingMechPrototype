using Code.Models;

namespace Code.Controllers.BuildingSystem.Abstractions
{
    public interface IBuildingController: IExecute, IDisable
    {
        public BuildingObjectModel ObjectModel { get; set; }
    }
}