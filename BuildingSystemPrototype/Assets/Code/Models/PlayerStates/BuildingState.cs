using System;
using Code.Controllers.BuildingSystem.Abstractions;
using Code.Controllers.MovementSystem.Abstractions;
using UnityEngine;

namespace Code.Models.PlayerStates
{
    public class BuildingState: IState
    {
        private BuildingChooseState _buildingChooseState;
        private IPlayerMovementController _playerMovementController;
        private IPlayerRotationController _playerRotationController;
        private IBuildingController _buildingController;
        private BuildingObjectModel _buildingObjectModel;

        public BuildingState(IPlayerMovementController playerMovementController, IPlayerRotationController playerRotationController, IBuildingController buildingController)
        {
            _playerMovementController = playerMovementController;
            _playerRotationController = playerRotationController;
            _buildingController = buildingController;
        }

        public BuildingObjectModel ObjectModel
        {
            set => _buildingObjectModel = value;
        }

        public void Inicialize(BuildingChooseState buildingChooseState)
        {
            _buildingChooseState = buildingChooseState;
        }
        public void Activate()
        {
            _playerMovementController.Activate();
            _playerRotationController.Activate();
            _buildingController.ObjectModel = _buildingObjectModel;
            _buildingController.Activate();
        }

        public void Deactivate()
        {
            _playerMovementController.Deactivate();
            _playerRotationController.Deactivate();
            _buildingController.ObjectModel = null;
            _buildingController.Deactivate();
        }

        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                OnStateChanged?.Invoke(_buildingChooseState);
            }
        }

        public event Action<IState> OnStateChanged;
    }
}