using System.Collections;
using System.Collections.Generic;
using Code.Controllers.ControllerMethods;
using Code.Controllers.MovementSystem.Abstractions;
using Code.Models;
using UnityEngine;

public class PlayerMovementController : IPlayerMovementController
{
    private PlayerView _playerView;
    private PlayerMovementModel _playerMovementModel;
    private bool _isActive;

    public PlayerMovementController(PlayerView playerView, PlayerMovementModel playerMovementModel)
    {
        _playerView = playerView;
        _playerMovementModel = playerMovementModel;
    }
    public void FixedExecute()
    {
        if (!_isActive)
        {
            return;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        var transform = _playerView.transform;
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        
        Vector3 newPosition =_playerView.Rigidbody.position + move * (_playerMovementModel.Speed * Time.fixedDeltaTime);
        _playerView.Rigidbody.MovePosition(newPosition);
    }

    public void Activate()
    {
        _isActive = true;
    }

    public void Deactivate()
    {
        _isActive = false;
    }

    public bool IsActive => _isActive;
}
