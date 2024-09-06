using System.Collections.Generic;
using Code.Models;
using Code.Views;
using UnityEngine;

public class BuildingObjectMenuModel
{
    public List<BuildingObjectModel> BuildingObjects { get; private set; }
    public BuildingObjectMenuView MenuView { get; private set; }
    public BuildingObjectIconView ObjectIconView { get; private set; }
    

    public BuildingObjectMenuModel(List<BuildingObjectModel> buildingObjects, BuildingObjectMenuView menuView, BuildingObjectIconView buildingObjectIconView)
    {
        BuildingObjects = buildingObjects;
        ObjectIconView = buildingObjectIconView;
        MenuView = GameObject.Instantiate(menuView);
        MenuView.gameObject.SetActive(false);
    }
}