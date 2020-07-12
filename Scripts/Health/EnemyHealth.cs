using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : HealthManager
{

    [Header("Enemy Health Conguration")]
    public Slider healthBar;

    private void setLifeSlider() {

        healthBar.value = getLife() / TotalHealthValue;

        if (getLife() <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            loseLife(collision.gameObject.GetComponent<BulletDamage>().getDamage());
            Destroy(collision.gameObject);
            setLifeSlider();
        }
    }
}
