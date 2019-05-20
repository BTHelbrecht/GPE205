using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;                        // This is to check and affect only a specific layer ... mainly the players layer
    public ParticleSystem m_ExplosionParticles;         // This is a referenc to play the explusion particales.
    public AudioSource m_ExplosionAudio;                // Refrecne to play explosion audio clip.
    public float m_MaxDamage = 100f;                    // The most damge the bullet can do.
    public float m_ExplosionForce = 1000f;              // force that you fee from distance of the bullet.
    public float m_MaxLifeTime = 2f;                    // Bullet kill timer to remove fromscene after an amount of time.
    public float m_ExplosionRadius = 5f;                // Radius of the blast from the center of the shell.


    private void Start()
    {
        // if the game object is active for more then 2 secondfs destroy it.
        Destroy(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Find all the tanks in an area around the shell and damage them.
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

        for(int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);

            targetHealth.TakeDamage(damage);
        }
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
        return 0f;
    }
}