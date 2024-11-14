using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _jumpForce;
    private GroundDetector _utility;

    private void Awake()
    {
        _utility = GetComponent<GroundDetector>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void DoJump(float jumpForce)
    {
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}