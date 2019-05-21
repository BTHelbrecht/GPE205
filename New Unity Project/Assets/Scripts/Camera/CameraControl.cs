using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f;                     // Time the camera takes to move to the new position
    public float m_ScreenEdgeBuffer = 4f;               // Buffer of the edge of the screen to make sure the Taanks stay on screen
    public float m_MinSize = 6.5f;                      // Minimum zoom in size
    [HideInInspector] public Transform[] m_Targets;     // NEEDED PUBLIC BUT NOT THROUGH INSPECTOR... camera is based on tank targets.


    private Camera m_Camera;                            // Reference to the camera to change the variable
    private float m_ZoomSpeed;                          // To dampen the movement speed
    private Vector3 m_MoveVelocity;                     // To dampen the zoom speed
    private Vector3 m_DesiredPosition;                  // The desired postion of the camera... The average of the take positions


    // Call at the beginning of the scene
    private void Awake()
    {
        // getting a component in a child object ... the main camera in the camera rig
        m_Camera = GetComponentInChildren<Camera>();
    }

    // call each physics update... used because the Tanks use it.
    private void FixedUpdate()
    {
        // calling the methods each update to see of the camera needs to move.
        Move();
        Zoom();
    }


    private void Move()
    {
        // Calling the method
        FindAveragePosition();

        // this is for smooth movement of the camera and the (ref) writes back to that vaariable. 
        // takes the position and moves to the new posistion based of it's last position. 
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


    private void FindAveragePosition()
    {
        // create new Vector3
        Vector3 averagePos = new Vector3();
        // int is the number of targets your averaging
        int numTargets = 0;

        // Goes through the list of players and or enemies.
        for (int i = 0; i < m_Targets.Length; i++)
        {   
            // first check if the tank is active
            // this wii eventually have it so the camera will zoom in on the take
            // that wins the round since the other tank deactivates.
            if (!m_Targets[i].gameObject.activeSelf)
                continue;
            // if active add that tanks position to the average posisition
            averagePos += m_Targets[i].position;
            // incrament the active numer of tanks.
            numTargets++;
        }

        // if targets are active
        if (numTargets > 0)
            // the devide the average posisiton by the numbe of players. 
            averagePos /= numTargets;
        // keeps ther camera rig at the ground position.
        averagePos.y = transform.position.y;
        // makes sure the camera y posisiton is 0
        m_DesiredPosition = averagePos;
    }


    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
    }


    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);

        float size = 0f;

        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);

            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));

            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / m_Camera.aspect);
        }
        
        size += m_ScreenEdgeBuffer;

        size = Mathf.Max(size, m_MinSize);

        return size;
    }


    public void SetStartPositionAndSize()
    {
        FindAveragePosition();

        transform.position = m_DesiredPosition;

        m_Camera.orthographicSize = FindRequiredSize();
    }
}