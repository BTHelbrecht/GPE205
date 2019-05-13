// MOTOR component (C#)

// UNITY Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// SPEC. --- NEEDED for text UI
using UnityEngine.UI;

/*
 * SCRIPT - FOR: ANY CANVAS STATS DISPLAY... BASIC
 * 
 * DESCRIPTION:
 * Used to display the score from health manager component
 * to display on screen in a canvas text.
 */
 
// INT. CLASS
public class ScoreDisplay : MonoBehaviour
{
    // Unmoveable score value
    public static int scoreValue = 0;
    // Text set to value for inspector
    Text life;



    // START METHOD - starts at INT.
    void Start()
    {
        // REWORDED: value = text component
        life = GetComponent<Text>();
    }// END --- start method

    // UPDATE METHOD - updates each frame
    void Update()
    {
        // REWORDED: value's text = "DISPLAY OUT"
        life.text = "LIVES: " + scoreValue;
    }// END --- update method
}// END --- CLASS
