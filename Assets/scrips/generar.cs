using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generar : MonoBehaviour
{

    public GameObject fresaPrefab;
    public Vector3[] posicionesFresas;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < posicionesFresas.Length; i++)
        {

            Instantiate(fresaPrefab, posicionesFresas[i], Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

   
}
