using Code.Controllers.BuildingSystem.Abstractions;
using Code.Models;
using Code.Views;
using DG.Tweening;
using UnityEngine;

namespace Code.Controllers.BuildingSystem
{
    public class BuildingController : IBuildingController
    {
        private BuildingObjectModel _buildingObjectModel;
        private bool _isActive;
        private BuildingObjectView _buildingObjectView;
        private PlayerView _playerView;
        private Renderer renderer;
        private BuildingModel _buildingModel;

        public BuildingController(BuildingModel buildingModel, PlayerView playerView)
        {
            _buildingModel = buildingModel;
            _playerView = playerView;
        }

        public void Execute()
        {
            if (!_isActive)
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            bool hitDetected = Physics.Raycast(ray, out hit, _buildingModel.MaxObjectDistance,
                _buildingModel.PlaceableSurfacesLayer);
            Vector3 targetPosition =
                hitDetected ? hit.point : ray.origin + ray.direction * _buildingModel.MaxObjectDistance;

            if (hitDetected)
            {
                targetPosition = CalculateSnappingPosition(hit);
            }

            HandleRotation();
            _buildingObjectView.transform.position = targetPosition;

            UpdateObjectColor();

            if (Input.GetMouseButtonDown(0))
            {
                PlaceObject();
            }
        }

        public void Activate()
        {
            _isActive = true;
            _buildingObjectView = GameObject.Instantiate(_buildingObjectModel.View, _playerView.transform);
            renderer = _buildingObjectView.GetComponent<Renderer>();
            _buildingObjectView.ChangeTriggerType(true);
            _buildingObjectView.gameObject.layer = _buildingModel.IgnoreRaycastLayer;
        }

        public void Deactivate()
        {
            _isActive = false;
            _buildingObjectView.transform.parent = null;
            GameObject.Destroy(_buildingObjectView.gameObject);
            _buildingObjectView = null;
            _buildingObjectModel = null;
        }

        public bool IsActive => _isActive;

        public BuildingObjectModel ObjectModel
        {
            get => _buildingObjectModel;
            set => _buildingObjectModel = value;
        }

        private void HandleRotation()
        {
            float scrollDelta = Input.mouseScrollDelta.y;

            if (Mathf.Approximately(scrollDelta, 0))
                return;

            float rotation = scrollDelta * _buildingModel._rotationAngle;
            _buildingObjectView.transform.localRotation =
                Quaternion.Euler(Vector3.up * rotation + _buildingObjectView.transform.localRotation.eulerAngles);
        }

        private void UpdateObjectColor()
        {
            if (_buildingObjectModel.PlacementCondition.CanBePlaced(_buildingObjectView))
            {
                renderer.material.color = new Color(0, 1, 0, 0.5f); // Зеленый цвет, если можно разместить
            }
            else
            {
                renderer.material.color = new Color(1, 0, 0, 0.5f); // Красный цвет, если нельзя
            }
        }

        private void PlaceObject()
        {
            if (!_buildingObjectModel.PlacementCondition.CanBePlaced(_buildingObjectView))
                return;
            _buildingObjectView.transform.parent = null;
            renderer.material.color = Color.white;
            _buildingObjectView.gameObject.layer = _buildingModel.DefaultLayer;
            _buildingObjectView.ChangeTriggerType(false);
            _buildingObjectView = null;
            Activate();
        }

        private Vector3 CalculateSnappingPosition(RaycastHit hit)
        {
            Vector3 snappedPosition = hit.point;
            if (hit.transform.gameObject.TryGetComponent<IPlacementSurface>(out var placementSurface) &&
                _buildingObjectView is ICanBePlaced canBePlaced &&
                canBePlaced.TryPlaceOn(out var position, placementSurface, snappedPosition))
            {
                return position;
            }

            return snappedPosition;
        }
    }
}