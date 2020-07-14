using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSliderHealth : HealthManager
{  public Slider healthBar;
   public GameManager GameManager;


    private void Start() {
       GameManager= GameObject.FindObjectOfType<GameManager>();
   }
    private void setLifeSlider() {

        healthBar.value = getLife() / TotalHealthValue;

        if (getLife() <= 0)
        {
              GameManager.LoseGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            loseLife(collision.gameObject.GetComponent<BulletDamage>().getDamage());
            Destroy(collision.gameObject);
            setLifeSlider();
        }
         if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<EnemyTracker>())
            {
                loseLife(collision.gameObject.GetComponent<EnemyTracker>().dano);
                 setLifeSlider();
              
            }
        }
    }
}
