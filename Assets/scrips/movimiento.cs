using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimiento : MonoBehaviour


{
    public Text contadorFresas;
    public Animator animator;
    public SpriteRenderer sprite;
    public float velocidad;
    public float salto;
    Rigidbody2D rigi;
    private int fresasRecolectadas = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>(); 
    }

     void FixedUpdate()
    {
        if(Input.GetKey("d") || Input.GetKey("right")) 
        {
            rigi.velocity = new Vector2(velocidad, rigi.velocity.y); //Mover a la derecha 
            transform.eulerAngles = new Vector3(0, 0, 0);
            animator.SetBool("Correr",true);
        }
        
        else if (Input.GetKey ("a") || Input.GetKey("left"))
            
        {
            rigi.velocity = new Vector2(-velocidad, rigi.velocity.y); //Mover a la izquierda
            transform.eulerAngles = new Vector3(0, 180, 0);
            animator.SetBool("Correr", true);
        }

        else 
        {
            rigi.velocity = new Vector2(0, rigi.velocity.y);
            animator.SetBool("Correr", false);
        }

        if (Input.GetKey("space") && detectarsalto.suelo)
        {
            rigi.velocity = new Vector2(rigi.velocity.x, salto);  //Para generar el salto cree un gameobject con un collider en los pies del personaje
                                                                  //para que dectecte cuando esta en el suelo y si esta en el suelo puede saltar, asi se evita el doble salto o salto infinito
        }

        if (detectarsalto.suelo == false)
        {
            animator.SetBool("Jump",true );
            animator.SetBool("Correr",false);

        }

        if (detectarsalto.suelo == true)
        {
            animator.SetBool("Jump", false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("fresas"))
        {

            Destroy(other.gameObject); 
            fresasRecolectadas++;
            Debug.Log("¡Fresa recolectada!");
            ActualizarContadorUI();
        }
        void ActualizarContadorUI()
        {
            // Actualizar el texto UI con la cantidad de monedas recolectadas
            contadorFresas.text = "Fresas: " + fresasRecolectadas.ToString();
        }

    }
}
