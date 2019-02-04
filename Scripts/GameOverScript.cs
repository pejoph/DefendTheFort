//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: GameOverScript.cs 		    						  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 15 / 01 / 2018							  /\\
//\     	   Last entry  - 19 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Controls the HUD and ends the game when lives run out. /\\                                                       /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public static int iScore;

    public int iHealth;
    public Canvas cGameOver;
    public Text tLives;
    public Text tScore;
    
	void Start ()
    {
        cGameOver.enabled = false;
        tLives.text = "20";
	}
	
	void Update ()
    {
		if (iHealth <= 0)
        {
            GameOver();
        }

        if (!cGameOver.enabled)
        {
            tScore.text = iScore.ToString();
        }        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Lose a life when an enemy reaches the centre.
        if (collision.tag == "Enemy")
        {
            iHealth -= 1;

            if (iHealth >= 0)
            {
                Destroy(collision.gameObject);
                tLives.text = iHealth.ToString();
            }
        }
    }

    // Bring up the game over screen.
    public void GameOver()
    {
        cGameOver.enabled = true;
    }

    // Restart game.
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
