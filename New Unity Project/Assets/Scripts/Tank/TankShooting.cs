using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;              // Identify what player is firing and reference to it.
    public Rigidbody m_Shell;                   // Reference for the shel prefab.
    public Transform m_FireTransform;           // Refrence to the pire point game object.
    public AudioSource m_ShootingAudio;         // Refrence to shooting audio source component.
    public AudioClip m_ChargingClip;            // Refrence to charging sound clip for firing the weapon.
    public AudioClip m_FireClip;                // Refrence to the firing sound clip for shooting.
    public float m_MinLaunchForce = 15f;        // Minimum launch potential for distance.
    public float m_MaxLaunchForce = 30f;        // Max launch potential for distance. 
    public float m_MaxChargeTime = 0.75f;       // Max time allowed for a player to charge there weapon.
    public float m_FireRate = 3;

    
    private string m_FireButton;                // Refrence for the input button which are strings and then this is for each player.
    private float m_CurrentLaunchForce;         // This is the state of force of when a player releases the charge of firing the weapon.
    private float m_ChargeSpeed;                // Refrence to the speed of the bullet.
    private float m_FireRateTime; 
    private bool m_Fired;                       // Refrence to whether the player has fired.


    // Calls when the tank is activated.
    private void OnEnable()
    {
        // This sets the current force to the minimum force for the launch force. 
        m_CurrentLaunchForce = m_MinLaunchForce;
    }

    // Calls at the start of the scene.
    private void Start()
    {
        // This is the fire button plus the player number to allow a player to shoot.
        m_FireButton = "Fire" + m_PlayerNumber;
        // Speed of the shell is the distance divided by the time to make the new speed for the shell.
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }
    
    // Calls once per-frame. THIS IS HANDLING ALL THE INPUT.
    private void Update()
    {
        if (Time.time > m_FireRateTime)
        {
            // Track the current state of the fire button and make decisions based on the current launch force.
            if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
            {
                // at max charge, not yet fired
                m_CurrentLaunchForce = m_MaxLaunchForce;
                Fire();
                FireRate();
            }
            else if (Input.GetButtonDown(m_FireButton))
            {
                // have we pressed fire for the first time?
                m_Fired = false;
                m_CurrentLaunchForce = m_MinLaunchForce;

                m_ShootingAudio.clip = m_ChargingClip;
                m_ShootingAudio.Play();
            }
            else if (Input.GetButton(m_FireButton) && !m_Fired)
            {
                // Holding the fire button, not yet fired
                // 
                m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;
            }
            else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
            {
                // we released the button, having not fired yet
                Fire();
                FireRate();
            }
        }
    }


    private void Fire()
    {
        // Instantiate and launch the shell.
        m_Fired = true;

        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

        m_CurrentLaunchForce = m_MinLaunchForce;
    }

    private void FireRate()
    {
        m_FireRateTime = Time.time + 1f / m_FireRate;
    }
}