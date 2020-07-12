using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GroundColor { Red, Yellow,  Blue }

public class GroundManager : MonoBehaviour
{
    public GameObject Player;

    public GroundColor Color;

    private PlayerShoot shootAttack;
    private PlayerDash dash;
    private PlayerJump jump;

    // Start is called before the first frame update
    void Start()
    {
        shootAttack = Player.GetComponent<PlayerShoot>();
        dash = Player.GetComponent<PlayerDash>();
        jump = Player.GetComponent<PlayerJump>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Desativa o tiro
            if (Color == GroundColor.Red) {

                shootAttack.enabled = false;
                dash.enabled = true;
                jump.enabled = true;

            // Desativa o dash
            } else if (Color == GroundColor.Yellow) {

                shootAttack.enabled = true;
                dash.enabled = false;
                jump.enabled = true;

            // Desativa o pulo
            } else if (Color == GroundColor.Blue) {

                shootAttack.enabled = true;
                dash.enabled = true;
                jump.enabled = false;
            }

        }
    }
}
