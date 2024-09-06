using Code.Controllers.MovementSystem.Abstractions;
using Code.Models;
using UnityEngine;

namespace Code.Controllers.MovementSystem
{
    public class PlayerRotationController: IPlayerRotationController
    {
        private PlayerView _playerView;
        private PlayerRotationModel _playerRotationModel;
        
        private float xRotation = 0f; 
        private bool _isActive;

        public PlayerRotationController(PlayerView playerView, PlayerRotationModel playerRotationModel)
        {
            _playerView = playerView;
            _playerRotationModel = playerRotationModel;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Execute()
        {
            if (!_isActive)
            {
                return;
            }
            
            float mouseX = Input.GetAxis("Mouse X") * _playerRotationModel.MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _playerRotationModel.MouseSensitivity * Time.deltaTime;
            _playerView.transform.Rotate(Vector3.up * mouseX);
            
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            _playerView.Camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        public void Activate()
        {
            _isActive = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Deactivate()
        {
            _isActive = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

        public bool IsActive => _isActive;
    }
}