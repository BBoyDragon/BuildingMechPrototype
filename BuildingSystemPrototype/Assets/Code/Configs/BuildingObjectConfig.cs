using Code.Models;
using Code.Views;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "BuildingObjectConfig", menuName = "Configs/BuildingObjectConfig", order = 1)]
    public class BuildingObjectConfig : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private string objectName;
        [SerializeField] private BuildingObjectView viewPrefab;
        [SerializeField] private PlacementConditionConfig placementConditionConfig;

        public Sprite Sprite => sprite;
        public string ObjectName => objectName;
        public BuildingObjectView ViewPrefab => viewPrefab;

        public BuildingObjectModel CreateModel()
        {
            return new BuildingObjectModel(sprite, objectName, viewPrefab, placementConditionConfig.Create());
        }
    }
}