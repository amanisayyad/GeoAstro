using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GameOver : MonoBehaviour
{
    public Text finalScoreText;

    void Start()
    {
        // Retrieve the saved score from PlayerPrefs
       // int finalScore = PlayerPrefs.GetInt("Score", 0);
        

        // Display the final score in the "Game Over" scene
        finalScoreText.text ="Final Score: ";
    }
}


    