using System.Collections.Generic;
using Code.Configs;
using Code.Models;
using Code.Views;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingObjectMenuConfig", menuName = "Configs/BuildingObjectMenuConfig", order = 2)]
public class BuildingObjectMenuConfig : ScriptableObject
{
    [SerializeField] private List<BuildingObjectConfig> buildingObjectConfigs;
    [SerializeField] private BuildingObjectMenuView menuViewPrefab;
    [SerializeField] private BuildingObjectIconView objectIconViewPrefab;

    public List<BuildingObjectConfig> BuildingObjectConfigs => buildingObjectConfigs;
    public BuildingObjectMenuView MenuViewPrefab => menuViewPrefab;

    public BuildingObjectIconView ObjectIconViewPrefab => objectIconViewPrefab;

    public BuildingObjectMenuModel CreateModel()
    {
        List<BuildingObjectModel> buildingModels = new List<BuildingObjectModel>();

        foreach (var config in buildingObjectConfigs)
        {
            buildingModels.Add(config.CreateModel());
        }

        return new BuildingObjectMenuModel(buildingModels, menuViewPrefab, objectIconViewPrefab);
    }
}