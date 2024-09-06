using Code.Views.Surfaces;
using UnityEngine;

namespace Code.Views
{
    public class CircleBuildingObject: BuildingObjectView, ICanBePlaced
    {
        private bool _isPlaced=false;
        public bool TryPlaceOn(out Vector3 place, IPlacementSurface surface, Vector3 snappedPosition)
        {
            if (surface is WallView wallView)
            {
                var point = wallView.GetClosestSurfacePoint(snappedPosition);
                place = point.position + wallView.transform.up * (gameObject.transform.localScale.x * 0.5f);
                _isPlaced = true;
                return true;
            }

            _isPlaced = false;
            place = snappedPosition;
            return false;
        }

        public bool IsPlaced { get; }
    }
}