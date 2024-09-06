using UnityEngine;

[CreateAssetMenu(fileName = "BuildingConfig", menuName = "Configs/BuildingConfig")]
public class BuildingConfig : ScriptableObject
{
    [SerializeField] private float maxObjectDistance = 3f;

    [SerializeField] private LayerMask placeableSurfacesLayer;

    [SerializeField] private int IgnoreRaycastLayer = 2;

    [SerializeField] private int DefaultLayer = 0;
    [SerializeField] private float _rotationAngle = 45f;

    public BuildingModel CreateBuildingModel()
    {
        return new BuildingModel(maxObjectDistance, placeableSurfacesLayer, IgnoreRaycastLayer,DefaultLayer, _rotationAngle);
    }
}