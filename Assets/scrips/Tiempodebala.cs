using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempodebala : MonoBehaviour
{
    [SerializeField] private float tiempodebala;

    private void Start()
    {
        Destroy(gameObject,tiempodebala);           //Script para que la bala se destruya y no quede en el mapa si no impacta con un collider.
    }
}
