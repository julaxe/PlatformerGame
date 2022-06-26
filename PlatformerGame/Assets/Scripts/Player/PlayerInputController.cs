using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector2 direction;

    public void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
        direction = direction.normalized;
    }
    
}
