using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class balajugador : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float damage;
    public int disparoajefe = 5;
    
    public int damagejefe;


    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
           Destroy(gameObject);
           Destroy(other.gameObject);              //Script creado para que el disparo del jugador pueda destruir o matar al enemigo.
        }

        if (other.CompareTag("Jefe"))
        {
            disparoajefe++;
            if (other.TryGetComponent(out jefe Jefe))
            {
                Jefe.TomarDamage(damagejefe);
                Destroy(gameObject);
            }
        }
    }

   

}
