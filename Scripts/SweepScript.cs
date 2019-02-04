//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: SweepScript.cs						    			  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 15 / 01 / 2018							  /\\
//\     	   Last entry  - 15 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Damages goblins if they are hit by the Holy Knight's   /\\
//\            sword.                                                 /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Damages goblins if they are hit by the Holy Knight's sword.
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<GoblinScript>().DamageReceived(50);
        }
    }
}
