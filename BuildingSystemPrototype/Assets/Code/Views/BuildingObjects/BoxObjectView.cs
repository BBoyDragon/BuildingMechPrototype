using System.Collections.Generic;
using Code.Views.Surfaces;
using UnityEngine;

namespace Code.Views
{
    public class BoxObjectView: BuildingObjectView, IPlacementSurface, ICanBePlaced
    {
        [SerializeField] private List<GameObject> _placeOnPositions;
        private bool _isPlaced=false;
        public Transform GetClosestSurfacePoint(Vector3 position)
        {
            GameObject closestObject = null;
            float closestDistanceSquared = float.MaxValue;

            foreach (GameObject obj in _placeOnPositions)
            {
                float distanceSquared = (position - obj.transform.position).sqrMagnitude;
                
                if (distanceSquared < closestDistanceSquared)
                {
                    closestDistanceSquared = distanceSquared;
                    closestObject = obj;
                }
            }
            return closestObject.transform;
        }

        public bool TryPlaceOn(out Vector3 place, IPlacementSurface surface, Vector3 snappedPosition)
        {
            if (surface is BoxObjectView boxObjectView)
            {
                var targetTransform = boxObjectView.GetClosestSurfacePoint(snappedPosition);
                place = targetTransform.position;
                transform.rotation = targetTransform.rotation;
                _isPlaced = true;
                return true;
            }

            if (surface is FloorView floorView)
            {
                place = floorView.GetClosestSurfacePoint(snappedPosition).position + Vector3.up * (gameObject.transform.localScale.y * 0.5f);
                _isPlaced = true;
                return true;
            }

            _isPlaced = false;
            place = snappedPosition;
            return false;
        }

        public bool IsPlaced => _isPlaced;
    }
}