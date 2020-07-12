using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagic : MonoBehaviour
{
    [Header("Enemy Configuration")]
    public GameObject Player;
    public float Miopia = 100f;

    public GameObject blueArea;
    public GameObject redArea;
    public GameObject yellowArea;

    public float TimeToChangeAreas = 3;

    private float currentTime = 0;

    private Animator animator;

    private void Start()
    {
        currentTime = TimeToChangeAreas;
        animator= this.gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.transform.position, this.transform.position) < Miopia)
        {
             if (currentTime<=2){
                     animator.SetBool("poder",true);  
                }
            if (currentTime <= 0)
            {
                animator.SetBool("poder",false);
              
                
                if (blueArea)
                {
                    
                    blueArea.GetComponent<GroundManager>().ChangeColor(chooseColorToChange(blueArea));
                     
                }
                if (redArea)
                {
                     
                    redArea.GetComponent<GroundManager>().ChangeColor(chooseColorToChange(redArea));
                     
                }
                if (yellowArea)
                {
                      
                    yellowArea.GetComponent<GroundManager>().ChangeColor(chooseColorToChange(yellowArea));
                     
                }

                 
                currentTime = TimeToChangeAreas;
            }

            currentTime -= Time.deltaTime;
        }
       
    }

    private GroundColor chooseColorToChange(GameObject area)
    {   
        
        GroundColor areaColor = (GroundColor)Random.Range(0, 3);
         

        while(areaColor == area.GetComponent<GroundManager>().Color)
        {
            areaColor = (GroundColor)Random.Range(0, 2);
            
             
        }
           
        
        return areaColor;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Miopia);
    }

    public IEnumerator stophiting(){
        yield return new WaitForSeconds(1f); 
        animator.SetBool("poder",false);
    }
}
