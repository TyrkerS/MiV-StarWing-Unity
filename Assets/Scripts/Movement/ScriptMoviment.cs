using UnityEngine;

public class ScriptMoviment : MonoBehaviour
{
    [SerializeField] 
    private float speedY = 5f;
    [SerializeField]
    private float speedX = 5f;
    [SerializeField]
    private float maxY = 4.5f;
    [SerializeField]
    private float minY = -4.5f;
    [SerializeField]
    private float maxX = 8.5f;
    [SerializeField]
    private float minX = -8.5f;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float ax = Input.GetAxis("Horizontal");
        float ay = Input.GetAxis("Vertical");

        // Aplicar la velocidad al Rigidbody con velocidades diferentes por eje
        rb.linearVelocity = new Vector3(ax * speedX, ay * speedY, 0);

        // Limitar la posición del objeto dentro de los límites definidos
        Vector3 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        // Aplicar la posición limitada
        rb.position = clampedPosition;
    }
}