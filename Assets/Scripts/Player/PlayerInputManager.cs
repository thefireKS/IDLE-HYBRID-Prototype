using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [HideInInspector] public Vector2 move;

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
}
