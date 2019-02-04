//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: FireScript.cs						    			  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 15 / 01 / 2018							  /\\
//\     	   Last entry  - 15 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Damages enemies if they stand in the fire.             /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Enemies in the fire take 1 damage per frame.
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<GoblinScript>().DamageReceived(1);
        }
    }
}
