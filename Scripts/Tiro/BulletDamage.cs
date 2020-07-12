using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private float damage;

    public float getDamage()
    {
        return damage;
    }

    public void setDamage(float value)
    {
        damage = value;
    }
}
