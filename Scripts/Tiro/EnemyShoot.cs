using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : ShootAttack
{
    [Header("Enemy Configuration")]
    public GameObject Player;
    public float Miopia = 100f;


    private void Start() {
        Player= GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.transform.position, this.transform.position) < Miopia)
        {
            if(Player.transform.position.x<this.transform.position.x){
            transform.rotation= new Quaternion(0,180,0,0);
        }
        else transform.rotation= new Quaternion(0,0,0,0);

       
            Vector2 direction = (Player.transform.position - this.transform.position).normalized;
            Shoot(direction);
        }

    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Miopia);
    }
}
