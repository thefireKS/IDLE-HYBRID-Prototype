using UnityEngine;

public class UICanvasControllerInput : MonoBehaviour
{

    [Header("Output")]
    public PlayerInputManager _PlayerInputManager;

    public void VirtualMoveInput(Vector2 virtualMoveDirection)
    {
        _PlayerInputManager.move = virtualMoveDirection;
    }
}