using Code.Models.PlacementConditions;
using Code.Models.PlacementConditions.Abstractions;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "IntoTriggerConditionConfig", menuName = "Configs/PlacementConditionConfig/IntoTriggerConditionConfig", order = 1)]
    public class IntoTriggerConditionConfig: PlacementConditionConfig
    {
        [SerializeField] private int triggersAmount=0;
        public override IPlacementCondition Create()
        {
            return new IntoTriggerCondition(triggersAmount);
        }
    }
}