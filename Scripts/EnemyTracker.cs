using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    [Header("Enemy Configuration")]
    public GameObject Player;
    public float Miopia = 100f;

    public float MoveSpeed = 4;
    public float dano = 10;


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.transform.position, this.transform.position) < Miopia)
        {
            transform.LookAt(Player.transform.position);
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);

            Vector3 direction = (Player.transform.position - this.transform.position).normalized;

            transform.position += direction * MoveSpeed * Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Miopia);
    }
}
