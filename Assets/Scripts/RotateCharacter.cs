using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCharacter : MonoBehaviour
{
    public Transform goToRotate;
    public Vector3 angularSpeed;
    public InputMaster input;
    InputAction action;

    private void Awake()
    {
        input = new InputMaster();
        input.Enable();
    }

    private void OnDestroy()
    {
        input.Disable();
    }

    private void Update()
    {
        var val = input.Player.RotatePlayer.ReadValue<float>();
        if (val == 1)
            goToRotate.Rotate(-1 * angularSpeed * Time.deltaTime);
        else if (val == -1)
            goToRotate.Rotate(angularSpeed * Time.deltaTime);
    }
}
