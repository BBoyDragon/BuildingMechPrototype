using Code.Models.PlacementConditions.Abstractions;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "PlacementConditionConfig", menuName = "Configs/PlacementConditionConfig", order = 1)]
    public abstract class PlacementConditionConfig: ScriptableObject
    {
        public abstract IPlacementCondition Create();
    }
}