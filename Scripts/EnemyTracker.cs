using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    [Header("Enemy Configuration")]
    public GameObject Player;
    public float Miopia = 100f;

    public float MoveSpeed = 30;
    public float dano = 10;

    private Animator animator;


    private void Start()
    {
        animator = this.transform.GetChild(0).GetComponent<Animator>();
        animator.SetBool("Andando",false);
        animator.SetBool("Atacando",false);
        Player= GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
         
        if (Vector2.Distance(Player.transform.position, this.transform.position) < Miopia)
        {
            walktowardsplayer();
        }
        
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Miopia);
    }


    void walktowardsplayer()
    {   
        animator.SetBool("Andando",true);
        transform.LookAt(Player.transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);
        if(Player.transform.position.x<this.transform.position.x){
            transform.rotation= new Quaternion(0,180,0,0);
        }
        else transform.rotation= new Quaternion(0,0,0,0);

        Vector3 direction = (Player.transform.position - this.transform.position).normalized;

        transform.position += direction * MoveSpeed * Time.deltaTime;
    }

    

     private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag=="Player"){
            
            animator.SetBool("Andando",false);
            animator.SetBool("Atacando",true);
        }


    }

     private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag=="Player"){
             
            animator.SetBool("Andando",true);
            animator.SetBool("Atacando",false);
        }
     }
}
