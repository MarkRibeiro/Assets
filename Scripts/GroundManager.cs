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

    public SpriteRenderer coelho;
    public SpriteRenderer coruja;
    private GameObject raposa;

 
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        shootAttack = Player.GetComponent<PlayerShoot>();
        dash = Player.GetComponent<PlayerDash>();
        jump = Player.GetComponent<PlayerJump>();

        coelho= GameObject.FindGameObjectWithTag("coelho").GetComponent<SpriteRenderer>();
        coruja= GameObject.FindGameObjectWithTag("coruja").GetComponent<SpriteRenderer>();
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
            Debug.Log("vermelho");
            shootAttack.enabled = false;
            dash.enabled = true;
            jump.enabled = true;
            
            

            
 
           
            // Desativa o dash
        }
        else if ( groundColor == GroundColor.Yellow)
        {
            Color invisivel=new Color(255,255,255);
            invisivel.a= 0.43f;
 
            
            shootAttack.enabled = true;
            dash.enabled = false;
            jump.enabled = true; 
            coelho.GetComponent<Animator>().SetBool("Inativo",true);
            
            
           

            // Desativa o pulo
        }
        else if ( groundColor == GroundColor.Blue)
        {

            shootAttack.enabled = true;
            dash.enabled = true;
            jump.enabled = false;
            coruja.GetComponent<SpriteRenderer>().color= new Color (255,255,255,alpha);

            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            deactivatePowers();

        }
    }

}
