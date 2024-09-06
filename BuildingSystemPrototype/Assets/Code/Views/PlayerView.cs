using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField] private Camera _camera;

    public Rigidbody Rigidbody => _rigidbody;

    public Camera Camera => _camera;
}
