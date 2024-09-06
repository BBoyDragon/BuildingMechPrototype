using UnityEngine;

namespace Code.Views
{
    public interface IPlacementSurface
    {
        public Transform GetClosestSurfacePoint(Vector3 position);
    }
}