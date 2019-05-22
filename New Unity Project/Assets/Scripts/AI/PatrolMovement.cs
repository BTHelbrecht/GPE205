using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public float m_Speed;
    public Transform[] m_Locations;
    public GameObject m_Tank;
    

    private int m_RandomLocation;

    void Awake()
    {
        m_Tank.GetComponent<TankMovement>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_RandomLocation = Random.Range(0, m_Locations.Length);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position,  m_Locations[m_RandomLocation].position, m_Speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, m_Locations[m_RandomLocation].position) < 0.2f)
        {
            m_RandomLocation = Random.Range(0, m_Locations.Length);
        }
    }
}
