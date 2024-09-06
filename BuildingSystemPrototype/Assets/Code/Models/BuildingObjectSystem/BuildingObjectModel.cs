using Code.Models.PlacementConditions.Abstractions;
using Code.Views;
using UnityEngine;

namespace Code.Models
{
    public class BuildingObjectModel
    {
        public Sprite Sprite { get; private set; }
        public string Name { get; private set; }
        public BuildingObjectView View { get; private set; }
        
        public IPlacementCondition PlacementCondition { get; private set; }

        public BuildingObjectModel(Sprite sprite, string name, BuildingObjectView view, IPlacementCondition placementCondition)
        {
            Sprite = sprite;
            Name = name;
            View = view;
            PlacementCondition = placementCondition;
        }
    }
}