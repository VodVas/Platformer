using UnityEngine;

public class Move : MonoBehaviour
{
    private InputReader _inputReader;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void DoMove(float speed)
    {
        float moveX = _inputReader.HorizontalMove;

        Vector2 move = new Vector2(moveX * speed, _rigidbody.velocity.y);

        _rigidbody.velocity = move;

        if (moveX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveX), 1, 1);
        }
    }
}