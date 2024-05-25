using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo1 : MonoBehaviour
{
    public float velocidad;
    public int damage;

    private void Update()
    {
        transform.Translate(Time.deltaTime * velocidad*Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out vidajugador vidaJugador))    //sistema de quitar vida.
        {
            vidaJugador.TomarDamage(damage);
            Destroy(gameObject);
        }
    }
}
