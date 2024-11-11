using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";
    public const string IsRunning = "IsRunning";
    public const string IsWalking = "IsWalking";
    public const string IsFight = "IsFight";
    public const string IsIdle = "IsIdle";
    public const string Jump = "Jump";
    public const string Run = "Run";

    public bool IsMouseButtonDown { get; private set; }
    public float HorizontalMove { get; private set; }
    public bool IsJump { get; private set; }
    public bool IsRun { get; private set; }

    private void Update()
    {
        IsMouseButtonDown = Input.GetKeyDown(KeyCode.Mouse0);
        HorizontalMove = Input.GetAxisRaw(Horizontal);
        IsJump = Input.GetButtonDown(Jump);
        IsRun = Input.GetButton(Run);
    }
}