using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float DashSpeed = 30f;

    private PlayerMovement Player;
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.GetComponent<PlayerMovement>();
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            jump();
        }
    }

    private void jump()
    {
        // Faz o player subir por um tempinho, faz ele descer dps desse tempinho
        //Vector2 movement = movement.normalized * speed * Time.deltaTime;
        //rigidbody.MovePosition(rigidbody.position + movement);
    }
}
