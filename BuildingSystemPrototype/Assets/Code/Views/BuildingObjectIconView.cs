using System;
using Code.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Views
{
    public class BuildingObjectIconView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Button _useButton;
        private BuildingObjectModel _model;

        public void Setup(BuildingObjectModel model)
        {
            _model = model;
            _image.sprite = model.Sprite;
            _name.text = _model.Name;
            _useButton.onClick.AddListener(PickIcon);
        }

        public void OnDestroy()
        {
            _useButton.onClick.RemoveAllListeners();
        }

        private void PickIcon()
        {
            OnButtonWasUsed?.Invoke(_model);
        }

        public event Action<BuildingObjectModel> OnButtonWasUsed;
    }
}