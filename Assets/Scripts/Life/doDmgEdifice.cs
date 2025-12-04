using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class doDmgEdifice : MonoBehaviour
{
    [SerializeField]
    private float damage = 10f; // Daño que se aplica
    [SerializeField]
    private float damageInterval = 1f; // Tiempo entre cada aplicación de daño

    // Diccionario para rastrear los Coroutines por objeto
    private Dictionary<HealthScript, Coroutine> activeCoroutines = new Dictionary<HealthScript, Coroutine>();

    // Componente de sonido
    [SerializeField] private AudioClip collisionSound; // Sonido de colisión
    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto tiene HealthScript al entrar
        HealthScript health = other.GetComponent<HealthScript>();
        if (health != null && !activeCoroutines.ContainsKey(health))
        {
            // Iniciar el Coroutine y guardarlo en el diccionario
            Coroutine coroutine = StartCoroutine(ApplyContinuousDamage(health));
            activeCoroutines[health] = coroutine;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto tiene HealthScript al salir
        HealthScript health = other.GetComponent<HealthScript>();
        if (health != null && activeCoroutines.ContainsKey(health))
        {
            // Detener el Coroutine asociado y eliminarlo del diccionario
            StopCoroutine(activeCoroutines[health]);
            activeCoroutines.Remove(health);
            Debug.Log("Salida detectada, daño detenido.");
        }
    }

    private IEnumerator ApplyContinuousDamage(HealthScript health)
    {
        while (health != null)
        {
            health.TakeDamage(damage);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}