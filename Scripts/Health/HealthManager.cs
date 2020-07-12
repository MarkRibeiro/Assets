using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header ("Health Configuration")]
    public float TotalHealthValue = 30;


    private float currentLife;

    private void Awake()
    {
        currentLife = TotalHealthValue;
    }

    public float getLife()
    {
        return currentLife;
    }

    public void loseLife(float value)
    {
        Debug.Log("Perdeu vida");
        currentLife -= value;
    }

    public void gainLife(float value)
    {
        currentLife += value;
    }
}
