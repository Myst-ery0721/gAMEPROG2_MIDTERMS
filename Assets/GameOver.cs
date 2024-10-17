using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel; 

    void Start()
    {
        
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); 
        }
        else
        {
            Debug.LogError("Game Over Panel is not assigned in the inspector!");
        }
    }

    public void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
        }
        else
        {
            Debug.LogError("Game Over Panel is not assigned in the inspector!");
        }
    }
}
