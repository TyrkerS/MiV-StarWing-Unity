using UnityEngine;

public class ScripAngle : MonoBehaviour
{
    [SerializeField]
    private float maxAngle = 20f; // Ángulo máximo de rotación
    [SerializeField]
    private float rotationSpeed = 50f; // Velocidad de rotación (y retorno)

    private float currentAngleZ = 0f; // Ángulo actual para izquierda/derecha (Z)
    private float currentAngleX = 0f; // Ángulo actual para arriba/abajo (X)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Capturar la entrada horizontal y vertical
        float horizontalInput = Input.GetAxis("Horizontal"); // Izquierda/Derecha
        float verticalInput = Input.GetAxis("Vertical");     // Arriba/Abajo

        // Calcular el ángulo para el eje Z (izquierda/derecha)
        if (Mathf.Abs(horizontalInput) > 0.01f)
        {
            float targetAngleZ = currentAngleZ + horizontalInput * rotationSpeed * Time.deltaTime;
            currentAngleZ = Mathf.Clamp(targetAngleZ, -maxAngle, maxAngle);
        }
        else
        {
            // Retorno suave al ángulo 0 usando la misma velocidad de rotación
            currentAngleZ = Mathf.MoveTowards(currentAngleZ, 0, rotationSpeed * Time.deltaTime);
        }

        // Calcular el ángulo para el eje X (arriba/abajo)
        if (Mathf.Abs(verticalInput) > 0.01f)
        {
            float targetAngleX = currentAngleX - verticalInput * rotationSpeed * Time.deltaTime;
            currentAngleX = Mathf.Clamp(targetAngleX, -maxAngle, maxAngle);
        }
        else
        {
            // Retorno suave al ángulo 0 usando la misma velocidad de rotación
            currentAngleX = Mathf.MoveTowards(currentAngleX, 0, rotationSpeed * Time.deltaTime);
        }

        // Aplicar la rotación combinada
        transform.rotation = Quaternion.Euler(currentAngleX, 0, -currentAngleZ);
    }
}
