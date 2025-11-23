using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentoFA : MonoBehaviour
{
    public float fuerza = 10f;     // Magnitud de la fuerza (N)
    public Vector3 direccion = Vector3.right; // Dirección de la fuerza
    public bool aplicarFuerza = true;

    private Rigidbody rb;
    private Vector3 velocidadAnterior;
    private float tiempoAcumulado = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidadAnterior = rb.velocity;
    }

    void FixedUpdate()
    {
        // Aplicamos fuerza constante solo si está activado
        if (aplicarFuerza)
        {
            rb.AddForce(direccion.normalized * fuerza, ForceMode.Force);
        }

        // Calculamos aceleración aproximada cada FixedUpdate
        float dt = Time.fixedDeltaTime;
        Vector3 velocidadActual = rb.velocity;
        Vector3 aceleracion = (velocidadActual - velocidadAnterior) / dt;

        tiempoAcumulado += dt;

        // Cada ~0.5 s mostramos datos
        if (tiempoAcumulado >= 0.5f)
        {
            Debug.Log($"t = {Time.time:F2}s | m = {rb.mass} kg | F = {fuerza} N | a ≈ {aceleracion.magnitude:F2} m/s²");
            tiempoAcumulado = 0f;
        }

        velocidadAnterior = velocidadActual;
    }
}

