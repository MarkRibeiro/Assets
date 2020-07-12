using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : ShootAttack
{
    [Header("Enemy Configuration")]
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (Player.transform.position - this.transform.position).normalized;
        Shoot(direction);
    }
}
