using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagic : MonoBehaviour
{
    [Header("Enemy Configuration")]
    public GameObject Player;
    public float Miopia = 100f;

    public GameObject[] blueArea;
    public GameObject[] redArea;
    public GameObject[] yellowArea;

    public float TimeToChangeAreas = 3;

    private float currentTime = 0;

    private Animator animator;

    private void Start()
    {
        currentTime = TimeToChangeAreas;
        animator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.transform.position, this.transform.position) < Miopia)
        {
            if (Player.transform.position.x < this.transform.position.x)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else transform.rotation = new Quaternion(0, 0, 0, 0);


            if (currentTime <= 2)
            {
                animator.SetBool("poder", true);
            }
            if (currentTime <= 0)
            {
                animator.SetBool("poder", false);


                if (blueArea.Length > 0)
                {
                    foreach(GameObject area in blueArea)
                    {
                        area.GetComponent<GroundManager>().ChangeColor(chooseColorToChange(area));
                    }

                }
                if (redArea.Length > 0)
                {
                    foreach (GameObject area in redArea)
                    {
                        area.GetComponent<GroundManager>().ChangeColor(chooseColorToChange(area));
                    }

                }
                if (yellowArea.Length > 0)
                {
                    foreach (GameObject area in yellowArea)
                    {
                        area.GetComponent<GroundManager>().ChangeColor(chooseColorToChange(area));
                    }

                }


                currentTime = TimeToChangeAreas;
            }

            currentTime -= Time.deltaTime;
        }

    }

    private GroundColor chooseColorToChange(GameObject area)
    {

        GroundColor areaColor = (GroundColor)Random.Range(0, 3);


        while (areaColor == area.GetComponent<GroundManager>().Color)
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


}
