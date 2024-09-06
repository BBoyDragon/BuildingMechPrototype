using System;
using Code.Controllers.CreateObjectMenuSystem;
using Code.Controllers.CreateObjectMenuSystem.Abstractions;
using UnityEngine;
using Zenject;

namespace Code.Models.PlayerStates
{
    public class BuildingChooseState: IState, IClean
    {
        private MovementState _movementState;
        private BuildingState _buildingState;
        private ICreateObjectMenuController _createObjectMenuController;

        public BuildingChooseState(ICreateObjectMenuController createObjectMenuController, BuildingState buildingState)
        {
            _createObjectMenuController = createObjectMenuController;
            _buildingState = buildingState;
            _buildingState.Inicialize(this);
        }

        public void Inicialize(MovementState movementState)
        {
            _movementState = movementState;
        }

        public void Activate()
        {
           _createObjectMenuController.Activate();
           _createObjectMenuController.OnBuildingObjectChosen += StartBuilding;
           
        }

        public void Deactivate()
        {
            _createObjectMenuController.OnBuildingObjectChosen -= StartBuilding;
           _createObjectMenuController.Deactivate();
        }

        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                OnStateChanged?.Invoke(_movementState);
            }
        }

        private void StartBuilding(BuildingObjectModel buildingObjectModel)
        {
            _buildingState.ObjectModel = buildingObjectModel;
            OnStateChanged?.Invoke(_buildingState);
        }

        public event Action<IState> OnStateChanged;
        public void Clean()
        {
            _createObjectMenuController.OnBuildingObjectChosen -= StartBuilding;
        }
    }
}