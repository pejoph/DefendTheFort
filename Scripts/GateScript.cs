//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: GateScript.cs 		        						  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 15 / 01 / 2018							  /\\
//\     	   Last entry  - 15 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Controls gate health.                                  /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public int iHealth;
    public int iMaxHealth;

	void Update ()
    {
        // Destroy gate.
        if (iHealth <= 0)
        {
            Destroy(gameObject);
        }	
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Gate loses health if enemies are adjacent.
        if (collision.gameObject.tag == "Enemy")
        {
            iHealth -= 1;
        }
    }
}
