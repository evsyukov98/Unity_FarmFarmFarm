using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerContoller : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private FixedJoystick joystick;

    [SerializeField] private float moveSpeed;
    
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        MovePlayerWithJoystick();
    }

    void Update()
    {
        
    }

    private void MovePlayerWithJoystick()
    {
        var horizontalSpeed = GetJoystickInputXZ().Item1 * moveSpeed;
        var verticalSpeed = GetJoystickInputXZ().Item2 * moveSpeed;
        rigidbody.velocity = new Vector3(horizontalSpeed, rigidbody.velocity.y, verticalSpeed);
    }
    
    private (float, float) GetJoystickInputXZ()
    {
        return (joystick.Horizontal, joystick.Vertical);
    }
}
