using UnityEngine;

public class Utility : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _minYVelocity = 0.01f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public bool IsGrounded()
    {
        return Mathf.Abs(_rigidbody.velocity.y) < _minYVelocity;
    }
}