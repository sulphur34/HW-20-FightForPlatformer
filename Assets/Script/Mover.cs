using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void MoveHorizontal(float movementSpeed)
    {
        _rigidBody.velocity = new Vector2(movementSpeed, _rigidBody.velocity.y);
    }

    public void MoveVertical(float jumpSpeed)
    {
        if (Mathf.Abs(_rigidBody.velocity.y) < 0.1)
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, jumpSpeed);
    }
}

