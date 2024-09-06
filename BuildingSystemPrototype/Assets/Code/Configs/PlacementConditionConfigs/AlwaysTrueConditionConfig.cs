using Code.Models.PlacementConditions;
using Code.Models.PlacementConditions.Abstractions;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "AlwaysTrueConditionConfig", menuName = "Configs/PlacementConditionConfig/AlwaysTrueConditionConfig", order = 1)]
    public class AlwaysTrueConditionConfig : PlacementConditionConfig
    {
        public override IPlacementCondition Create()
        {
            return new AlwaysTrueCondition();
        }
    }
}