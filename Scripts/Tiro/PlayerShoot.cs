﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : ShootAttack
{
    [Header("Player Shoot Configuration")]
    public Camera camera;

    public GameObject Cursor;

    // Update is called once per frame
    void Update()
    {
        // Botão esquerdo do mouse
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 direction = (Vector2)(camera.ScreenToWorldPoint(Input.mousePosition) - this.transform.position).normalized;
            Shoot(direction);
        }

        // Cursor da mira
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100;
        Vector2 target = camera.ScreenToWorldPoint(Input.mousePosition);
        Cursor.transform.position = target;
    }
}
