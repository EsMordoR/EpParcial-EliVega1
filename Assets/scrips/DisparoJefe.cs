using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJefe : MonoBehaviour
{
    public Transform controladorDisparo;
    public float distanciaLinea;
    public LayerMask capaJugador;
    public bool jugadorRange;
    public GameObject BalaEnemigo1;
    public float tiempodisparo;
    public float ultimodisparo;
    public float tiempodeespera;
    public Animator animator;


    private void Update()
    {
        jugadorRange= Physics2D.Raycast(controladorDisparo.position,transform.right, distanciaLinea,capaJugador);
        if(jugadorRange)
        {
            if(Time.time >tiempodisparo+ ultimodisparo)
            {
                ultimodisparo = Time.time;
                animator.SetTrigger("Disparar");                  //Sistema de disparo con animacion y tiempo de espera entre disparos
                                                                  //Nos ayudamos con los Gizmos para señalar donde disparar 
                
                Invoke(nameof(Disparar),tiempodeespera);
            }
        }
    }

    private void Disparar()
    {
        Instantiate(BalaEnemigo1,controladorDisparo.position,controladorDisparo.rotation);
    }
                                                                                             //Prefab creado para el disparo del jefe 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position,controladorDisparo.position + transform.right*distanciaLinea);
    }
}
