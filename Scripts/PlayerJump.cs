using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerMovement Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 Movement = new Vector2(Player.lastMoveHorizontal, Player.lastMoveVertical).normalized;
        }
    }
}
