using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public enum GroundColor { Red, Yellow,  Blue }

public class GroundManager : MonoBehaviour
{
    public GameObject Player;

    public GroundColor Color;

    public Color Red;
    public Color Yellow;
    public Color Blue;

    private PlayerShoot shootAttack;
    private PlayerDash dash;
    private PlayerJump jump;

    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        shootAttack = Player.GetComponent<PlayerShoot>();
        dash = Player.GetComponent<PlayerDash>();
        jump = Player.GetComponent<PlayerJump>();

    }

    public void ChangeColor(GroundColor color)
    {
        Color = color;

        Light2D light = this.transform.GetChild(1).GetComponent<Light2D>();

        if (color == GroundColor.Blue)
        {
            light.color = Blue;

        } else if (color == GroundColor.Red)
        {
            light.color = Red;

        } else if (color == GroundColor.Yellow)
        {
            light.color = Yellow;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("caralho KD");

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
