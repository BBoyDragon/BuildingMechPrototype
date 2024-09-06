using System.Collections.Generic;
using UnityEngine;

namespace Code.Views
{
    public class BuildingObjectView: MonoBehaviour
    {
        private Collider _collider;
        private Collider Collider
        {
            get
            {
                if (_collider == null)
                {
                    _collider = gameObject.GetComponent<Collider>();
                }
                return _collider;
            }
        }
        private HashSet<Collider> _collidersInTrigger = new HashSet<Collider>();

        public void ChangeTriggerType(bool type)
        {
           _collidersInTrigger.Clear();
           Collider.isTrigger = type;
        }

        private void OnTriggerEnter(Collider other)
        {
            _collidersInTrigger.Add(other);
        }

        private void OnTriggerExit(Collider other)
        {
            _collidersInTrigger.Remove(other);
        }

        public int GetObjectCount()
        {
            return _collidersInTrigger.Count;
        }
    }
}