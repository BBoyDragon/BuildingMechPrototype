using Code.Models.PlacementConditions.Abstractions;
using Code.Views;
using Unity.VisualScripting;

namespace Code.Models.PlacementConditions
{
    public class IntoTriggerCondition: IPlacementCondition
    {
        private int _triggersAmount;

        public IntoTriggerCondition(int triggersAmount)
        {
            _triggersAmount = triggersAmount;
        }

        public bool CanBePlaced(BuildingObjectView buildingObjectView)
        {
            return buildingObjectView.GetObjectCount() == _triggersAmount;
        }
    }
}