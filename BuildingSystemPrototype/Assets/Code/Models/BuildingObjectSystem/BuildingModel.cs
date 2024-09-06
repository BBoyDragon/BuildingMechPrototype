using UnityEngine;

public class BuildingModel
{
    public float MaxObjectDistance { get; private set; }
    public LayerMask PlaceableSurfacesLayer { get; private set; }
    public int IgnoreRaycastLayer { get; private set; }
    public int DefaultLayer { get; private set; }

    public float _rotationAngle { get; private set; }

    public BuildingModel(float maxObjectDistance, LayerMask placeableSurfacesLayer, int ignoreRaycastLayer, int defaultLayer, float rotationAngle)
    {
        MaxObjectDistance = maxObjectDistance;
        PlaceableSurfacesLayer = placeableSurfacesLayer;
        IgnoreRaycastLayer = ignoreRaycastLayer;
        DefaultLayer = defaultLayer;
        _rotationAngle = rotationAngle;
    }

    public void SetToIgnoreRaycast(GameObject obj)
    {
        obj.layer = IgnoreRaycastLayer;
    }

    public void SetToDefaultLayer(GameObject obj)
    {
        obj.layer = DefaultLayer;
    }
}