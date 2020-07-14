using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public enum GroundColor { Red, Yellow,  Blue }

public class GroundManager : MonoBehaviour
{
    private GameObject Player;

    public GroundColor groundColor;

    public Color Red;
    public Color Yellow;
    public Color Blue;

    public float alpha = 43.0f;

    private PlayerShoot shootAttack;
    private PlayerDash dash;
    private PlayerJump jump;

    public  GameObject coelho;
    public  GameObject coruja;
    private GameObject  raposa;

 
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        shootAttack = Player.GetComponent<PlayerShoot>();
        dash = Player.GetComponent<PlayerDash>();
        jump = Player.GetComponent<PlayerJump>();

        coelho= GameObject.FindGameObjectWithTag("coelho");
        coruja= GameObject.FindGameObjectWithTag("coruja");
        raposa= GameObject.FindGameObjectWithTag("raposa");
    
 


    }

    public void ChangeColor(GroundColor color)
    {
         groundColor = color;
         

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

        deactivatePowers();
    }

    private void deactivatePowers()
    {
       
        // Desativa o tiro
        if ( groundColor == GroundColor.Red)
        {
            Debug.Log("red");
            shootAttack.enabled = false;
            dash.enabled = true;
            jump.enabled = true;
            raposa.GetComponent<Animator>().SetBool("Inativo",true);
            coruja.GetComponent<Animator>().SetBool("Inativo",false);
            coelho.GetComponent<Animator>().SetBool("Inativo",false);
            

            
 
           
            // Desativa o dash
        }
        else if ( groundColor == GroundColor.Yellow)
        { 
 
            Debug.Log("Yellow");
            shootAttack.enabled = true;
            dash.enabled = false;
            jump.enabled = true; 
            coelho.GetComponent<Animator>().SetBool("Inativo",true);
            raposa.GetComponent<Animator>().SetBool("Inativo",false);
            coruja.GetComponent<Animator>().SetBool("Inativo",false);
            
            
           

            // Desativa o pulo
        }
        else if ( groundColor == GroundColor.Blue)
        {
             Debug.Log("blue");
            shootAttack.enabled = true;
            dash.enabled = true;
            jump.enabled = false;
            coruja.GetComponent<Animator>().SetBool("Inativo",true);
            raposa.GetComponent<Animator>().SetBool("Inativo",false);
            coelho.GetComponent<Animator>().SetBool("Inativo",false);
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            deactivatePowers();

        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        raposa.GetComponent<Animator>().SetBool("Inativo",false);
        coruja.GetComponent<Animator>().SetBool("Inativo",false);
        coelho.GetComponent<Animator>().SetBool("Inativo",false);
    }

}
