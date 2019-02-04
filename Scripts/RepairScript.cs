//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: RepairScript.cs						    			  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 15 / 01 / 2018							  /\\
//\     	   Last entry  - 16 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Controls stonemason's repair ability.                  /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairScript : MonoBehaviour
{
    public int iRepairPower;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Increase gate health if health is less than max.
        if (collision.tag == "Gate" && collision.GetComponent<GateScript>().iHealth < collision.GetComponent<GateScript>().iMaxHealth)
        {
            collision.GetComponent<GateScript>().iHealth += iRepairPower;

            if (collision.GetComponent<GateScript>().iHealth > collision.GetComponent<GateScript>().iMaxHealth)
            {
                collision.GetComponent<GateScript>().iHealth = collision.GetComponent<GateScript>().iMaxHealth;
            }
        }

        // Fix ballisa if broken.
        if (collision.tag == "Ballista" && collision.GetComponent<BallistaScript>().bIsBroken)
        {
            collision.GetComponent<BallistaScript>().iHealth += iRepairPower;
            collision.GetComponent<BallistaScript>().broken.GetComponent<SpriteRenderer>().color = new Color(128.0f / 255.0f, 64.0f / 255.0f, 64.0f / 255.0f, (176.0f - (float)collision.GetComponent<BallistaScript>().iHealth / 2.0f ) / 255.0f);

            // Once health reaches max, ballista is restored and functions once more.
            if (collision.GetComponent<BallistaScript>().iHealth >= collision.GetComponent<BallistaScript>().iMaxHealth)
            {
                collision.GetComponent<BallistaScript>().iHealth = collision.GetComponent<BallistaScript>().iMaxHealth;
                collision.GetComponent<BallistaScript>().iAmmo = collision.GetComponent<BallistaScript>().iMaxAmmo;
                collision.GetComponent<BallistaScript>().bIsBroken = false;
                collision.GetComponent<BallistaScript>().broken.GetComponent<SpriteRenderer>().color = new Color(128.0f / 255.0f, 64.0f / 255.0f, 64.0f / 255.0f, 0.0f);
            }
        }
    }
}
