using System.Collections;
using System.Collections.Generic;
using Code.Configs;
using Code.Controllers.BuildingSystem;
using Code.Controllers.ChangeStateSystem;
using Code.Controllers.ControllerUtility;
using Code.Controllers.CreateObjectMenuSystem;
using Code.Controllers.MovementSystem;
using Code.Models;
using Code.Models.PlayerStates;
using UnityEngine;
using Zenject;

public class BuildingMechSceneInstaller : MonoInstaller
{
    private const string ControllerRunnerPrefabPath = "ControllerExecutorPrefab";

    public override void InstallBindings()
    {
        Container.Bind<Transform>().WithId("Environment")
            .FromComponentInNewPrefabResource("Prefabs/Environment")
            .AsSingle().NonLazy();
        Container.Bind<PlayerView>().FromComponentInNewPrefabResource("Prefabs/Player").AsSingle();

        Container.Bind<PlayerMovementConfig>()
            .FromMethod(() => Resources.Load<PlayerMovementConfig>("Configs/PlayerMovementConfig")).AsSingle();
        Container.Bind<PlayerMovementModel>().FromResolveGetter<PlayerMovementConfig>(config => config.Create())
            .AsSingle();
        Container.Bind<PlayerRotationConfig>()
            .FromMethod(() => Resources.Load<PlayerRotationConfig>("Configs/PlayerRotationConfig")).AsSingle();
        Container.Bind<PlayerRotationModel>().FromResolveGetter<PlayerRotationConfig>(config => config.Create())
            .AsSingle();
        Container.Bind<BuildingObjectMenuConfig>()
            .FromMethod(() => Resources.Load<BuildingObjectMenuConfig>("Configs/BuildingObjectMenuConfig")).AsSingle();
        Container.Bind<BuildingObjectMenuModel>()
            .FromResolveGetter<BuildingObjectMenuConfig>(config => config.CreateModel()).AsSingle();
        Container.Bind<BuildingConfig>().FromMethod(() => Resources.Load<BuildingConfig>("Configs/BuildingConfig"))
            .AsSingle();
        Container.Bind<BuildingModel>()
            .FromResolveGetter<BuildingConfig>(config => config.CreateBuildingModel()).AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerMovementController>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerRotationController>().AsSingle();
        Container.BindInterfacesAndSelfTo<CreateObjectMenuController>().AsSingle();
        Container.BindInterfacesAndSelfTo<BuildingController>().AsSingle();

        Container.BindInterfacesAndSelfTo<BuildingState>().AsSingle();
        Container.BindInterfacesAndSelfTo<BuildingChooseState>().AsSingle();
        Container.Bind<IState>().WithId("StartingState").To<MovementState>().AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerStateController>().AsSingle();


        Container.Bind<ControllerRunner>().FromComponentInNewPrefabResource(ControllerRunnerPrefabPath).AsSingle();
        Container.InstantiatePrefabResource(ControllerRunnerPrefabPath);
    }
}