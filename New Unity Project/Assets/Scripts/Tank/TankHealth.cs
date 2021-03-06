﻿using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float m_StartingHealth = 100f;           // Starting total of health = 100
    public Slider m_Slider;                         // Variable to reference values of the slider
    public Image m_FillImage;                       // To acces the fill gameobject
    public Color m_FullHealthColor = Color.green;   // green is for full health on the UI wheel
    public Color m_ZeroHealthColor = Color.red;     // red is for no health on the UI wheel
   
    
    
    private float m_CurrentHealth;                  // value for the current health
    private bool m_Dead;                            // value to check if player is dead or not

    


    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        SetHealthUI();
    }
    

    public void TakeDamage(float amount)
    {
        // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
        m_CurrentHealth -= amount;

        SetHealthUI();

        if(m_CurrentHealth <= 0f && !m_Dead)
        {
            OnDeath();
        }
    }


    private void SetHealthUI()
    {
        // Adjust the value and colour of the slider.
        m_Slider.value = m_CurrentHealth;

        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }


    private void OnDeath()
    {
        // Play the effects for the death of the tank and deactivate it.
        m_Dead = true;

        gameObject.SetActive(false);

    }
}

/*
 * THIS IS TO ADD tank explosion PARTICALES AT ANOTHER TIME.
 * 
 * public GameObject m_ExplosionPrefab;            // refrence to the explosion prefab
 *
 * private AudioSource m_ExplosionAudio;          
 * private ParticleSystem m_ExplosionParticles;  
 *  
 * private void Awake()
 {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }
    */
