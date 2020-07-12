using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : ShootAttack
{
    [Header("Enemy Configuration")]
    public GameObject Player;
    public float Miopia = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.transform.position, this.transform.position) < Miopia)
        {
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
