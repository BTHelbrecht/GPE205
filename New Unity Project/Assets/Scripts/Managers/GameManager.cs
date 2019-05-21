// GAME MANAGER

// UNITY
using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

// CLASS START
public class GameManager : MonoBehaviour
{
    // VARIABLES

    // Public
    public int m_NumRoundsToWin = 5;            // The number of round to to win the game.
    public float m_StartDelay = 3f;             // The delay of seconds to start a round.
    public float m_EndDelay = 3f;               // The delay of seconds after a round.
    public CameraControl m_CameraControl;       // Refrence to the camera control.
    public Text m_MessageText;                  // Refrence to the Display UI canvas.
    public GameObject m_TankPrefab;             // Refrence to the tank Prefab game object.
    public TankManager[] m_Tanks;               // Refrence to the tank mangaer script.

    // Private
    private int m_RoundNumber;                  // The actual round number.
    private WaitForSeconds m_StartWait;         // Co-routine for start delay.
    private WaitForSeconds m_EndWait;           // Co-routine for end delay.
    private TankManager m_RoundWinner;          // Intance of round winner, for message of each round.
    private TankManager m_GameWinner;           // Instance of game winner, for message of end game.



    // Calls at start of scene
    private void Start()
    {
        // sets up new delay for start
        // sets up new delay for end
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        // spawns all the tanks into the scene
        // set the camera targets for the camera rig to expand or collapse.
        SpawnAllTanks();
        SetCameraTargets();

        // this is used for time management of game flow and conditions.
        StartCoroutine(GameLoop());
    }



    // SpawnAllTanks Method... Spawns all tanks into the game by looping through the tank managers.
    private void SpawnAllTanks()
    {
        // loop through tank managers
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            // set an instance to an instantiated prefab tank
            // set the tank to the spawn point with a position and rotation of the spwan point.
            // set the tanks player number with counter and + 1 so the corect number for player is displayed.
            // set the start of tank stats.
            m_Tanks[i].m_Instance =
                Instantiate(m_TankPrefab, m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
            m_Tanks[i].m_PlayerNumber = i + 1;
            m_Tanks[i].Setup();
        }
    }



    // SetCameraTargets Method... Set the location for the camera based on tanks location using an array.
    private void SetCameraTargets()
    {
        // assign array of locations to new location at the same legth of the tank managers array.
        Transform[] targets = new Transform[m_Tanks.Length];

        // loop through the targets array for each target.
        for (int i = 0; i < targets.Length; i++)
        {
            // set the target to the tank managers instance location.
            targets[i] = m_Tanks[i].m_Instance.transform;
        }

        // set the camera controls target to tank managers targets
        m_CameraControl.m_Targets = targets;
    }



    // Co-Routine GameLoop Method... This basically takes the start/play/end motheds and loops them
    // on at a time and then checks if there is a winner. If not then is plays them again. If there
    // is a winner is shoots the player to a new scene.
    private IEnumerator GameLoop()
    {
        // wait for round starting to call and finish.
        // wait for round playing to call and finish.
        // wait for round end to call and finish.
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

        // if there is a winner go to the winner scene, otherwise start the Gameloop again.
        if (m_GameWinner != null)
        {
            // load winner scene.
            //SceneManager.LoadScene(0);
        }
        else
        {
            // call gameloop again.
            StartCoroutine(GameLoop());
        }
    }

    // START OF ROUND... setup the round
    private IEnumerator RoundStarting()
    {
        // reset all the tanks.
        // disable all tank controls.
        ResetAllTanks();
        DisableTankControl();

        // set the camera positions to tanks and set camera to start scaling.
        m_CameraControl.SetStartPositionAndSize();

        // add one to the round number.
        // display the round number.
        m_RoundNumber ++;
        m_MessageText.text = "ROUND " + m_RoundNumber;

        // wait # seconds.
        yield return m_StartWait;
    }

    // PLAY THE ROUND... play the game.
    private IEnumerator RoundPlaying()
    {
        // turns on all the tank scripts to play the game.
        EnableTankControl();

        // Display the UI to the screen.
        m_MessageText.text = ""; // could use ... string.Empty;

        // while there is not 1 tank left.. so if there are multiple tanks.
        while (!OneTankLeft())
        {
            // return null to signal one tank left in game.
            yield return null;
        }
    }

    // END THE ROUND... updates the player on whats happening in the game.
    private IEnumerator RoundEnding()
    {
        // turn off tank controls scripts.
        DisableTankControl();

        // chacks via tank manager if the is a winner.
        m_RoundWinner = null;

        // assign the active tank to the game winner.
        m_RoundWinner = GetRoundWinner();

        // check if there is a round winner.
        if(m_RoundWinner != null)
        {
            // add one to that tanks wins.
            m_RoundWinner.m_Wins++;
        }

        // assign the game winner if any.
        m_GameWinner = GetGameWinner();

        // assign the end game display text.
        // display the end game text.
        string message = EndMessage();
        m_MessageText.text = message;



        // wait # of seconds.
        yield return m_EndWait;
    }

    // OneTankLeft Method... loops through each tank to see who is the last active tank.
    private bool OneTankLeft()
    {
        // assign a default variable.
        int numTanksLeft = 0;

        // loop through each tank manager.
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            // if a tank is active.
            // add 1 to number of tanks.
            if (m_Tanks[i].m_Instance.activeSelf)
                numTanksLeft++;
        }

        // return that there is one tank.
        return numTanksLeft <= 1;
    }

    // GetRoundWinner Method... Looks through all the tank managers and finds which is active at the end of the round.
    private TankManager GetRoundWinner()
    {
        // loop through tanks.
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            // if it is active.
            // return that tanks index number.
            if (m_Tanks[i].m_Instance.activeSelf)
                return m_Tanks[i];
        }

        // return null if nothing is active and there is a draw.
        return null;
    }

    // GetGameWinner Method... Check to see if win conditions are met (5 ROUNDS).
    private TankManager GetGameWinner()
    {
        // loop through each tank manager.
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            // if the number of wins per tank equals 5 rounds.
            // return tank index number.
            if (m_Tanks[i].m_Wins == m_NumRoundsToWin)
                return m_Tanks[i];
        }

        // return null otherwise.
        return null;
    }

    // EndMessage Method... displays the results based on the conditions of game.
    private string EndMessage()
    {
        // defaults text as DRAW.
        string message = "DRAW!";

        // if the round winner is not null... there is a winner.
        // the display the last round winners color with text
        // READS: (players color) PLAYER(#) WINS THE ROUND.
        if (m_RoundWinner != null)
            message = m_RoundWinner.m_ColoredPlayerText + " WINS THE ROUND!";

        // formatting 4x linebreak.
        message += "\n\n\n\n";

        // loop though all the tanks and display the results for each tank.
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            // display tank and the wins they have
            // READS: (players color)(#): (#) WINS (linebreak).
            message += m_Tanks[i].m_ColoredPlayerText + ": " + m_Tanks[i].m_Wins + " WINS\n";
        }

        // if game winner is not null... if there is a winner.
        // the display is the winner.
        // READS: (players color) Player(#) WINS THE GAME!
        if (m_GameWinner != null)
            message = m_GameWinner.m_ColoredPlayerText + " WINS THE GAME!";

        // Return with the message that applies.
        return message;
    }

    // loops through each tank manager and calls the reset method.
    private void ResetAllTanks()
    {
        // loop
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].Reset();
        }
    }

    // loops through each tank manager and calls the enable controls method.
    private void EnableTankControl()
    {
        // loop
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].EnableControl();
        }
    }

    // loops through each tank manager and calls the disable controls method.
    private void DisableTankControl()
    {
        // loop
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].DisableControl();
        }
    }
}