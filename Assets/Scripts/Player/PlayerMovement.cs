using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputManager _playerInputManager;
    private CharacterController _characterController;

    private void Start()
    {
        _playerInputManager = GetComponent<PlayerInputManager>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 targetDirection = new Vector3(_playerInputManager.move.x, 0, _playerInputManager.move.y);
        _characterController.Move(targetDirection * Time.deltaTime);
    }
}
