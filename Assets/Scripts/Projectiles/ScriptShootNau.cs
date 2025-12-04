using UnityEngine;

public class ScriptShoot : MonoBehaviour
{

    [SerializeField]
    private float speed = 10f; // Velocidad de la bala

    [SerializeField]
    private float bulletLifetime = 3f; // Tiempo de vida de la bala

    [SerializeField]
    private float attackSpeed = 0.5f; // Tiempo entre disparos (velocidad de ataque)

    [SerializeField]
    private GameObject bulletPrefab; // Prefab de la bala a instanciar

    [SerializeField]
    private Transform firePoint; // Punto donde se instanciará la bala

    private float nextShotTime = 0f; // Control del tiempo entre disparos

    private AudioSource audioSource; // AudioSource para el sonido del disparo

    [SerializeField] private AudioClip shootSound; // Sonido del disparo

    void Start(){
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = shootSound;
    }
    
    void Update()
    {
        // Disparo continuo mientras la tecla Z esté presionada
        if (Input.GetKey(KeyCode.Z) && Time.time >= nextShotTime)
        {
            audioSource.Play(); // Reproducir el sonido del disparo
            Shoot();
            nextShotTime = Time.time + attackSpeed; // Configura el tiempo para el próximo disparo
        }
    }

    private void Shoot()
    {
        // Instanciar la bala en el firePoint con su rotación actual
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();


        // Aplicar movimiento hacia adelante
        if (rb != null)
        {
            rb.linearVelocity = transform.forward * speed;
        }

        // Destruir la bala después del tiempo definido
        Destroy(bullet, bulletLifetime);
    }
}
