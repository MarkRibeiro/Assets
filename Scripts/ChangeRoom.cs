using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public GameObject porta;
    public GameObject inimigosAnterior;
    public GameObject inimigosProximo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inimigosAnterior.SetActive(false);
        inimigosProximo.SetActive(true);

        porta.SetActive(true);
    }

}
