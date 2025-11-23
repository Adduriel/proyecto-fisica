using UnityEngine;

public class UpdateVsFixed : MonoBehaviour
{
    public float fuerza = 10f;
    public bool usarUpdate = false;      // Si es true, aplica en Update
    public bool usarFixedUpdate = true;  // Si es true, aplica en FixedUpdate

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (usarUpdate)
        {
            rb.AddForce(Vector3.forward * fuerza);
        }
    }

    void FixedUpdate()
    {
        if (usarFixedUpdate)
        {
            rb.AddForce(Vector3.forward * fuerza);
        }
    }
}

