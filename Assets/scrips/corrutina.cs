using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corrutina : MonoBehaviour

{
    public float velocidad = 5f;
    private bool corriendo = false;
    private Coroutine correrCoroutine;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!corriendo && Input.GetKeyDown(KeyCode.F))
        {
            correrCoroutine = StartCoroutine(CorrerContinuamenteCoroutine());
            corriendo = true;
            animator.SetBool("Correx", true);
        }
        else if (corriendo && Input.GetKeyDown(KeyCode.C))
        {
            StopCoroutine(correrCoroutine);
            corriendo = false;
            animator.SetBool("Correx", false);
        }
    }

    IEnumerator CorrerContinuamenteCoroutine()
    {
        while (true)
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            yield return null;
        }
    }
}  
