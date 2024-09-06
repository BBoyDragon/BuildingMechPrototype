using System;
using Code.Controllers.CreateObjectMenuSystem.Abstractions;
using Code.Models;
using Code.Views;

namespace Code.Controllers.CreateObjectMenuSystem
{
    public class CreateObjectMenuController: ICreateObjectMenuController
    {
        private BuildingObjectMenuModel _model;

        public CreateObjectMenuController(BuildingObjectMenuModel model)
        {
            _model = model;
        }

        public void Activate()
        {
            _model.MenuView.gameObject.SetActive(true);
            _model.MenuView.SetupIcons(_model.BuildingObjects,_model.ObjectIconView);
            foreach (BuildingObjectIconView buildingObjectIconView in _model.MenuView.ActiveIcons)
            {
                buildingObjectIconView.OnButtonWasUsed += Pick;
            }
        }

        public void Deactivate()
        {
            foreach (BuildingObjectIconView buildingObjectIconView in _model.MenuView.ActiveIcons)
            {
                buildingObjectIconView.OnButtonWasUsed -= Pick;
            }
            _model.MenuView.CleanUpICons();
            _model.MenuView.gameObject.SetActive(false);
        }

        private void Pick(BuildingObjectModel buildingObjectModel)
        {
            OnBuildingObjectChosen?.Invoke(buildingObjectModel);
        }
        public bool IsActive => _model.MenuView.isActiveAndEnabled;
        public event Action<BuildingObjectModel> OnBuildingObjectChosen;
        public void Clean()
        {
            foreach (BuildingObjectIconView buildingObjectIconView in _model.MenuView.ActiveIcons)
            {
                buildingObjectIconView.OnButtonWasUsed -= Pick;
            }
        }
    }
}