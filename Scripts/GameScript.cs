//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: GameScript.cs         								  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 14 / 01 / 2018							  /\\
//\     	   Last entry  - 19 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Controls game processes not connected with any         /\\
//\            game object .                                          /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject goblin;
    public GameObject NorthSpawn;
    public GameObject SouthSpawn;
    public GameObject WestSpawn;
    public GameObject EastSpawn;
    public Canvas cMenu;
    public GameObject huntress;
    public GameObject seer;
    public GameObject holyKnight;
    public GameObject stonemason;
    public Transform tPlayer1Spawn;
    public Transform tPlayer2Spawn;
    public Transform tPlayer3Spawn;
    public Transform tPlayer4Spawn;
    public GameObject gameOver;
    
    private float fTimer = 0;
    private float fSpawnInterval = 2.0f;

    public void Start ()
    {
        // Spawns the character each player chose in the right starting position.
        if (cMenu.GetComponent<MenuScript>().Player1select == MenuScript.PLAYERSELECT.HUNTRESS)
        {
            GameObject player1 = Instantiate(huntress, tPlayer1Spawn);
            player1.transform.parent = null;
        }
        else if (cMenu.GetComponent<MenuScript>().Player1select == MenuScript.PLAYERSELECT.SEER)
        {
            GameObject player1 = Instantiate(seer, tPlayer1Spawn);
            player1.transform.parent = null;
        }
        else if (cMenu.GetComponent<MenuScript>().Player1select == MenuScript.PLAYERSELECT.HOLYKNIGHT)
        {
            GameObject player1 = Instantiate(holyKnight, tPlayer1Spawn);
            player1.transform.parent = null;
        }
        else if (cMenu.GetComponent<MenuScript>().Player1select == MenuScript.PLAYERSELECT.STONEMASON)
        {
            GameObject player1 = Instantiate(stonemason, tPlayer1Spawn);
            player1.transform.parent = null;
        }

        if (cMenu.GetComponent<MenuScript>().Player2select == MenuScript.PLAYERSELECT.HUNTRESS)
        {
            GameObject player2 = Instantiate(huntress, tPlayer2Spawn);
            player2.transform.parent = null;
        }
        else if (cMenu.GetComponent<MenuScript>().Player2select == MenuScript.PLAYERSELECT.SEER)
        {
            GameObject player2 = Instantiate(seer, tPlayer2Spawn);
            player2.transform.parent = null;
        }
        else if (cMenu.GetComponent<MenuScript>().Player2select == MenuScript.PLAYERSELECT.HOLYKNIGHT)
        {
            GameObject player2 = Instantiate(holyKnight, tPlayer2Spawn);
            player2.transform.parent = null;
        }
        else if (cMenu.GetComponent<MenuScript>().Player2select == MenuScript.PLAYERSELECT.STONEMASON)
        {
            GameObject player2 = Instantiate(stonemason, tPlayer2Spawn);
            player2.transform.parent = null;
        }

        if (cMenu.GetComponent<MenuScript>().Player3select == MenuScript.PLAYERSELECT.HUNTRESS)
        {
            GameObject player3 = Instantiate(huntress, tPlayer3Spawn);
            player3.transform.parent = null;
        }
        else if (cMenu.GetComponent<MenuScript>().Player3select == MenuScript.PLAYERSELECT.SEER)
        {
            GameObject player3 = Instantiate(seer, tPlayer3Spawn);
            player3.transform.parent = null;
        }
        else if (cMenu.GetComponent<MenuScript>().Player3select == MenuScript.PLAYERSELECT.HOLYKNIGHT)
        {
            GameObject player3 = Instantiate(holyKnight, tPlayer3Spawn);
            player3.transform.parent = null;
        }
        else if (cMenu.GetComponent<MenuScript>().Player3select == MenuScript.PLAYERSELECT.STONEMASON)
        {
            GameObject player3 = Instantiate(stonemason, tPlayer3Spawn);
            player3.transform.parent = null;
        }

        if (cMenu.GetComponent<MenuScript>().Player4select == MenuScript.PLAYERSELECT.HUNTRESS)
        {
            GameObject player4 = Instantiate(huntress, tPlayer4Spawn);
            player4.transform.parent = null;
        }
        else if (cMenu.GetComponent<MenuScript>().Player4select == MenuScript.PLAYERSELECT.SEER)
        {
            GameObject player4 = Instantiate(seer, tPlayer4Spawn);
            player4.transform.parent = null;
        }
        else if (cMenu.GetComponent<MenuScript>().Player4select == MenuScript.PLAYERSELECT.HOLYKNIGHT)
        {
            GameObject player4 = Instantiate(holyKnight, tPlayer4Spawn);
            player4.transform.parent = null;
        }
        else if (cMenu.GetComponent<MenuScript>().Player4select == MenuScript.PLAYERSELECT.STONEMASON)
        {
            GameObject player4 = Instantiate(stonemason, tPlayer4Spawn);
            player4.transform.parent = null;
        }
    }

    void Update ()
    {
        // Allocates enemies to different spawn locations.
        if (fTimer <= Time.time && gameOver.GetComponent<GameOverScript>().iHealth > -200)
        {
            int iRand = Random.Range(1, 5);

            if (iRand == 1)
            {
                SpawnEvent(NorthSpawn);
            }
            else if (iRand == 2)
            {
                SpawnEvent(WestSpawn);
            }
            else if (iRand == 3)
            {
                SpawnEvent(SouthSpawn);
            }
            else if (iRand == 4)
            {
                SpawnEvent(EastSpawn);
            }
            
            fTimer = Time.time + fSpawnInterval;
            Mathf.Clamp(fSpawnInterval -= .01f, 0.0f, 2.0f);            
        }
	}

    // Spawns enemies.
    private void SpawnEvent(GameObject spawnPoint)
    {
        GameObject enemy = Instantiate(goblin, spawnPoint.transform);
        enemy.transform.parent = null;
    }
}
