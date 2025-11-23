using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarProyectil : MonoBehaviour
{
    public float fuerzaInicial = 1000f;
    private Rigidbody rb;
    private bool lanzado = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Lanza el proyectil una sola vez cuando presionas espacio
        if (!lanzado && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * fuerzaInicial);
            lanzado = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Colisión con: {collision.gameObject.name} | " +
                  $"v antes y después se reflejan según acción–reacción.");
    }
}
