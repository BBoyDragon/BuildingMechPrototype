using UnityEngine;

namespace Code.Views.Surfaces
{
    public class WallView: MonoBehaviour, IPlacementSurface
    {
        [SerializeField] private GameObject point;
        public Transform GetClosestSurfacePoint(Vector3 position)
        {
            point.transform.position = position;
            return point.transform;
        }
    }
}