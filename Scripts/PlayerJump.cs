using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerMovement Player;
    private Animator animation;

    public bool podepular=true;

    // Start is called before the first frame update
    void Start()
    {
        Player = this.GetComponent<PlayerMovement>();
        animation = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(podepular==true){
             Vector2 Movement = new Vector2(Player.lastMoveHorizontal, Player.lastMoveVertical).normalized;
             
            animation.SetBool("Pulando", true);
             Player.gameObject.GetComponent<SpriteRenderer>().color= Color.red;
             Player.gameObject.GetComponent<BoxCollider2D>().enabled=false;
             
            
            StartCoroutine(Pulocooldown());
            }
            
        }
    }
    IEnumerator Pulocooldown(){
        podepular=false;
         
        yield return new WaitForSeconds(3f);
        animation.SetBool("Mexendo", false);
        animation.SetBool("Pulando", false);
        Player.gameObject.GetComponent<BoxCollider2D>().enabled=true;
        Player.gameObject.GetComponent<SpriteRenderer>().color= Color.white;
        podepular=true;
        


    }
}
