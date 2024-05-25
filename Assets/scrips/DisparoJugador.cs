using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour

{
    public delegate void DisparoCooldownDelegate(float tiempoRestanteNormalizado);

    public Animator animator;
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    [SerializeField] private GameObject bala2;
    public float shootCooldown;
    private bool canShoot = true;
    public enum TipoAtaque
    {
        AtaqueNormal,
        AtaqueEspecial
    }

    private TipoAtaque tipoDeAtaqueActual = TipoAtaque.AtaqueNormal;
    public static event DisparoCooldownDelegate OnDisparoCooldown;

    private void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.X))
        {
            CambiarAtaque();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RealizarAtaque();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RealizarAtaque(2f);
        }
    }

    void CambiarAtaque()
    {
        
        tipoDeAtaqueActual = (tipoDeAtaqueActual == TipoAtaque.AtaqueNormal) ? TipoAtaque.AtaqueEspecial : TipoAtaque.AtaqueNormal;

        
    }



    void RealizarAtaque()
    {
        if (canShoot)
        {
            canShoot = false;

            switch (tipoDeAtaqueActual)
            {
                case TipoAtaque.AtaqueNormal:
                    

                    {

                        
                        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
                        animator.SetTrigger("Shot");
                        

                        Invoke("EnableShooting", shootCooldown);

                    }
                    break;
                case TipoAtaque.AtaqueEspecial:
                   

                    {

                        
                        Instantiate(bala2, controladorDisparo.position, controladorDisparo.rotation);
                        animator.SetTrigger("Shot");
                        

                        Invoke("EnableShooting", shootCooldown);
                    }



                    break;
                default:
                    break;
            }
            Invoke("EnableShooting", shootCooldown);

            
            OnDisparoCooldown?.Invoke(1f);
        }
    }

    void RealizarAtaque(float velocidadDisparo)
    {
        Debug.Log("Disparo especial con velocidad: " + velocidadDisparo);

        if (canShoot)
        {
            canShoot = false;

            switch (tipoDeAtaqueActual)
            {
                case TipoAtaque.AtaqueNormal:
                    Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
                    animator.SetTrigger("Shot");
                    velocidadDisparo = 5f;
                    break;
                case TipoAtaque.AtaqueEspecial:
                    Instantiate(bala2, controladorDisparo.position, controladorDisparo.rotation);
                    animator.SetTrigger("Shot");
                    break;
                    
                default:
                    break;
            }

            Invoke("EnableShooting", shootCooldown);
            OnDisparoCooldown?.Invoke(1f);
        }
    }


    void EnableShooting()
    {
        canShoot = true;
        

    }
   
}
