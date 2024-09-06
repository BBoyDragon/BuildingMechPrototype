using Code.Views;

namespace Code.Models.PlacementConditions.Abstractions
{
    public interface IPlacementCondition
    {
        public bool CanBePlaced(BuildingObjectView buildingObjectView);
    }
}