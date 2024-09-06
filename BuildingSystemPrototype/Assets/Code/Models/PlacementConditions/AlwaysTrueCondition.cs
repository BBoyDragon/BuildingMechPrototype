using Code.Models.PlacementConditions.Abstractions;
using Code.Views;

namespace Code.Models.PlacementConditions
{
    public class AlwaysTrueCondition: IPlacementCondition
    {

        public bool CanBePlaced(BuildingObjectView buildingObjectView)
        {
            return true;
        }
    }
}