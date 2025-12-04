using UnityEngine;

public class ScriptShoPowerUp : MonoBehaviour
{
    [SerializeField]
    public GameObject specialProjectilePrefab; // Prefab del proyectil especial
    [SerializeField]
    public Transform firePoint; // Punto desde donde se dispara el proyectil
    [SerializeField]
    public float projectileSpeed = 10f; // Velocidad del proyectil
    [SerializeField]
    public float explosionRadius = 5f; // Radio de la explosiÃ³n
    [SerializeField]
    public int explosionDamage = 50; // DaÃ±o de la explosiÃ³n

    private float accumulatedDamage = 0f; // DaÃ±o acumulado
    [SerializeField]
    private float damageThreshold = 200f; // LÃmite para habilitar el disparo especial

    [SerializeField]private Barra BarraPUp;

    public GameObject HUDBarra;

    public GameObject canvas;

    private AudioSource audioSource;

    [SerializeField] private AudioClip laserSound;

    private AudioSource audioSource2;

    [SerializeField] private AudioClip rechargeSound;

    private int i = 0;


    void Start()
    {
        canvas = GameObject.Find("PausaVida");
        HUDBarra = canvas.transform.Find("Panel")?.gameObject;
        BarraPUp = HUDBarra.transform.Find("BarraPUp2").GetComponent<Barra>();
        BarraPUp.InicialitzarBarraPUp(damageThreshold);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = laserSound;

        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.playOnAwake = false;
        audioSource2.clip = rechargeSound;
    }

    void Update()
    {
        // Detectar la tecla X para disparar el proyectil especial
        if (Input.GetKeyDown(KeyCode.X) && accumulatedDamage >= damageThreshold)
        {
            audioSource.Play();
            print("¡Disparando proyectil especial!");
            ShootSpecialProjectile();
            accumulatedDamage = 0; // Reinicia el contador de daÃ±o
            i=0;
            BarraPUp.ActualitzarPowerUp(accumulatedDamage);
        }
    }

    public void AddDamage(float damage)
    {
        accumulatedDamage += damage;
        BarraPUp.ActualitzarPowerUp(accumulatedDamage);
        if (accumulatedDamage >= damageThreshold)
        {
            if (i == 0)
            {
                audioSource2.Play();
                i++;
            }
            print("¡Proyectil especial listo para disparar!");
        }
    }

    void ShootSpecialProjectile()
    {
        GameObject projectile = Instantiate(specialProjectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * projectileSpeed;
        }

        doDmgPowerUp specialScript = projectile.GetComponent<doDmgPowerUp>();
        if (specialScript != null)
        {
            specialScript.Initialize(explosionRadius, explosionDamage);
        }
    }
}