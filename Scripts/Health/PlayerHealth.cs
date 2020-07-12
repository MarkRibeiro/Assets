using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthManager
{
    [Header("Player Health Conguration")]

    public GameManager GameManager;
    public GameObject[] lifes; 


    private void removeLifeFromHUD()
    {
        for (int i = lifes.Length - 1; i >= 0; i--)
        {
            if (lifes[i].activeSelf)
            {
                lifes[i].SetActive(false);
                break;
            }
        }

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
            removeLifeFromHUD();
            Destroy(collision.gameObject);
        }
    }
}
