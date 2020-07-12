using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : MonoBehaviour
{
    [Header("Shoot Configuration")]

    public GameObject BulletSprite;

    public float Force = 20;
    public float FireRate = 0.3f;
    public float dano = 10;

    // Wait for the fire rate
    private float waitTimeToShoot = 0f;

    public void Shoot(Vector2 direction)
    {
        if (waitTimeToShoot <= 0)
        {
            GameObject bullet = Instantiate(BulletSprite, this.transform.position, BulletSprite.transform.rotation);

            bullet.GetComponent<BulletDamage>().setDamage(dano);

            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

            bulletRB.AddForce(direction * Force, ForceMode2D.Impulse);

            waitTimeToShoot = FireRate;

        } else
        {
            waitTimeToShoot -= Time.deltaTime;
        }
    }

}
