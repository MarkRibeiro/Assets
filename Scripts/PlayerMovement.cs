using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10f;

    private Rigidbody2D rigidbody;
    [HideInInspector] public float lastMoveVertical;
    [HideInInspector] public float lastMoveHorizontal;
    private Animator animation;

    private void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        animation= this.GetComponent<Animator>();
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
            transform.rotation= new Quaternion(0,180,0,0);

        } else if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1;
            transform.rotation= new Quaternion(0,0,0,0);
        }

        lastMoveVertical = moveVertical;
        lastMoveHorizontal = moveHorizontal;

        movement.Set(moveHorizontal, moveVertical);
        Walk(movement, Speed);
        if (moveVertical == 0 && moveHorizontal == 0){
           animation.SetBool("Mexendo",false); 
        }
    }

    public void Walk(Vector2 movement, float speed)
    {
        animation.SetBool("Mexendo",true);
        movement = movement.normalized * speed * Time.deltaTime;
        rigidbody.MovePosition(rigidbody.position + movement);
    }
}
