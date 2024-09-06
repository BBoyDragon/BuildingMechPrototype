using System.Collections.Generic;
using System.Linq;
using Code.Models;
using UnityEngine;

namespace Code.Views
{
    public class BuildingObjectMenuView: MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        private List<BuildingObjectIconView> _activeIcons;

        public IReadOnlyList<BuildingObjectIconView> ActiveIcons => _activeIcons;

        public void SetupIcons(List<BuildingObjectModel> models, BuildingObjectIconView prefab)
        {
            _activeIcons = new List<BuildingObjectIconView>();
            foreach (BuildingObjectModel objectModel in models)
            {
                _activeIcons.Add(Instantiate(prefab, _container.transform));
                _activeIcons.Last().Setup(objectModel);
            }
        }

        public void CleanUpICons()
        {
            _activeIcons.ForEach(icon=>Destroy(icon.gameObject));
            _activeIcons.Clear();
        }
    }
}