using UnityEngine;

public class ScriptMovZ : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // Velocidad de movimiento
    [SerializeField]
    private float zFinal = -20f; // Posición final en el eje Z
    private float speedOriginal; // Velocidad original del objeto

    // Start se llama una vez antes
    void Start()
    {
        speedOriginal = speed; // Guarda la velocidad original
    }
    
    // Update se llama una vez por frame
    void Update()
    {
        // Mover el objeto hacia la posición zFinal
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(transform.position.x, transform.position.y, zFinal),
            speed * Time.deltaTime
        );

        // Destruir el objeto si llega a la posición final
        if (Mathf.Abs(transform.position.z - zFinal) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    // Método para modificar la velocidad de movimiento
    public void ModifySpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // Método para obtener la velocidad original del objeto
    public float GetOriginalSpeed()
    {
        return speedOriginal;
    }
}
