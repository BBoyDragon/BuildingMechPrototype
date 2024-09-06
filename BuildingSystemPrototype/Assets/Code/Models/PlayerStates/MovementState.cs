using System;
using Code.Controllers.MovementSystem;
using UnityEngine;
using Zenject;

namespace Code.Models.PlayerStates
{
    public class MovementState: IState
    {
        private PlayerMovementController _playerMovementController;
        private PlayerRotationController _playerRotationController;
        private BuildingChooseState _buildingChooseState;
        
        public MovementState(PlayerMovementController playerMovementController, PlayerRotationController playerRotationController,BuildingChooseState buildingChooseState)
        {
            _playerMovementController = playerMovementController;
            _playerRotationController = playerRotationController;
            _buildingChooseState = buildingChooseState;
            _buildingChooseState.Inicialize(this);
        }

        public void Activate()
        {
            _playerMovementController.Activate();
            _playerRotationController.Activate();
        }

        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                OnStateChanged?.Invoke(_buildingChooseState);
            }
        }

        public event Action<IState> OnStateChanged;

        public void Deactivate()
        {
            _playerMovementController.Deactivate();
            _playerRotationController.Deactivate();
        }
    }
}