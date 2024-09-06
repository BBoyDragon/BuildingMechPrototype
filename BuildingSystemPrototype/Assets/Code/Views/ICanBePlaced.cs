using UnityEngine;

namespace Code.Views
{
    public interface ICanBePlaced
    {
        public bool TryPlaceOn(out Vector3 place,IPlacementSurface surface, Vector3 snappedPosition);
        public bool IsPlaced { get; }
    }
}