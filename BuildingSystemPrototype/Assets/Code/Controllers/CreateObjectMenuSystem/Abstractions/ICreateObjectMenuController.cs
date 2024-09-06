using System;
using Code.Models;

namespace Code.Controllers.CreateObjectMenuSystem.Abstractions
{
    public interface ICreateObjectMenuController: IDisable, IClean
    {
        public event Action<BuildingObjectModel> OnBuildingObjectChosen;
    }
}