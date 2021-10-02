using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerContoller : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _moveSpeed;
    
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(
            _joystick.Horizontal * _moveSpeed,
            _rigidbody.velocity.y,
            _joystick.Vertical * _moveSpeed);
    }

    void Update()
    {
        
    }

    private void MovePlayerWithJoystick()
    {
        var horizontalSpeed = GetJoystickInputXZ().Item1 * _moveSpeed;
        var verticalSpeed = GetJoystickInputXZ().Item2 * _moveSpeed;
        _rigidbody.velocity = new Vector3(horizontalSpeed, _rigidbody.velocity.y, verticalSpeed);
    }
    
    private (float, float) GetJoystickInputXZ()
    {
        return (_joystick.Horizontal, _joystick.Vertical);
    }
}
