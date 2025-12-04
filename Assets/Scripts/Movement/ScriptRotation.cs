using UnityEngine;

public class ScriptRotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationAxis = Vector3.up; // Eje de rotación (por defecto el eje Y)
    [SerializeField]
    private float rotationSpeed = 10f; // Velocidad de rotación en grados por segundo

    // Update is called once per frame
    void Update()
    {
        // Rotar el objeto alrededor del eje especificado
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
