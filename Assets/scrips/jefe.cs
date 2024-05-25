using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jefe : Enemigo
{
   
    public int cantidaddevida;
    public void TomarDamage(int damage)
    {
        cantidaddevida -= damage;
        if (cantidaddevida <= 0)
        {

            
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);   //Metodo de vida del Jefe
                                                                          //Y recibir daño




        }
        
    }
    
}
