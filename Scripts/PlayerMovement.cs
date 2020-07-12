using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10f;

    private Rigidbody2D rigidbody;
    public float lastMoveVertical;
    public float lastMoveHorizontal;

    private void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        Vector2 movement = Vector2.zero;

        float moveVertical = 0;
        float moveHorizontal = 0;

        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1;

        } else if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1;

        } else if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1;
        }

        lastMoveVertical = moveVertical;
        lastMoveHorizontal = moveHorizontal;

        movement.Set(moveHorizontal, moveVertical);
        Walk(movement, Speed);
    }

    public void Walk(Vector2 movement, float speed)
    {
        movement = movement.normalized * speed * Time.deltaTime;
        rigidbody.MovePosition(rigidbody.position + movement);
    }
}
