// TANK MANAGER

// UNITY
using System;
using UnityEngine;

// This allows this to be shown in the Inspector whne not in MonoBehaviour
// Custom class not made with MONOBEHAVIOUR 
[Serializable]
public class TankManager
{
    // VARIABLES

    // Public
    public Color m_PlayerColor;                             // Refrence to the player color for the UI.
    public Transform m_SpawnPoint;                          // Refrensce to the spawn points game objects.

    // Public
    // Hidden from the Inspector.
    [HideInInspector] public int m_PlayerNumber;            // Refrence to each player/enemy... used in TANK SHOOTING & TANK MOVEMENT.
    [HideInInspector] public string m_ColoredPlayerText;    // To show the text in the color of player.
    [HideInInspector] public GameObject m_Instance;         // This is to be able to turn on or off components/gameobject with the tank.
    [HideInInspector] public int m_Wins;                    // Track score for porpuse of determining winner.

    // Private
    private PatrolMovement m_PatrolMove;
    private RageMovement m_RageMove;
    private TankMovement m_Movement;                        // Refrence to the TANK MOVEMENT.
    private TankShooting m_Shooting;                        // Refrence to the TANK SHOOTING.
    private GameObject m_CanvasGameObject;                  // Refrence to the UI Cavas gameobject to turn UI on or off.



    // Setup Method... Called by the game manager to initialize tank stats.
    public void Setup()
    {
        // assign ref. from tank movement script
        // assign ref. from tank shooting script
        // assign ref. from patrol movement AI script
        // assign ref. from rage movement AI script
        // assign ref from child UI canavas 
        m_Movement = m_Instance.GetComponent<TankMovement>();
        m_Shooting = m_Instance.GetComponent<TankShooting>();
        m_PatrolMove = m_Instance.GetComponent<PatrolMovement>();
        m_RageMove = m_Instance.GetComponent<RageMovement>();
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        // setting the player number for moving script
        // setting the player number for shooting script
        m_Movement.m_PlayerNumber = m_PlayerNumber;
        m_Shooting.m_PlayerNumber = m_PlayerNumber;

        // player text readout to UI uses tags "<color> </color>".
        // READS: (Player Color) PLAYER(#) 
        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";

        // assign an array of mesh renderers setting to the components in children that are mesh renderers.
        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        // Takes all these mesh renderers and goes through each and sets this to the players number color.
        for (int i = 0; i < renderers.Length; i++)
        {
            // Set color.
            renderers[i].material.color = m_PlayerColor;
        }
    }



    // DisableControl Method... used to turn off scripts of tank
    public void DisableControl()
    {
        // turns off the movement script for tank
        // turns off the shooting script for tank
        m_Movement.enabled = false;
        m_Shooting.enabled = false;

        // turns off the cavas for the tank UI
        m_CanvasGameObject.SetActive(false);
    }



    // EnableControl Method... used to turn on scripts of tank
    public void EnableControl()
    {
        // turns on the movement script for tank
        // turns on the shooting script for tank
        m_Movement.enabled = true;
        m_Shooting.enabled = true;

        // turns on the cavas for the tank UI
        m_CanvasGameObject.SetActive(true);
    }



    // Reset Method... Sets the instance back to spwan point by turn it off, then on.
    public void Reset()
    {
        // resets the tanks position to the spawn point
        // resets the tanks rotation to that of spawn point
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        // turns instance off
        // turns instance on
        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}
