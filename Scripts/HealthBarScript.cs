//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: HealthBarScript.cs 						    		  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 15 / 01 / 2018							  /\\
//\     	   Last entry  - 15 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Controls health bar for North and South doors.         /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public GameObject greenBar;
    public GameObject gate;

    private Vector2 vPosition;
    private Vector2 vScale;

    void Start ()
    {
        vPosition = greenBar.transform.position;
        vScale = greenBar.transform.localScale;
    }
	
	void Update ()
    {
        // Green bar shrinks and moves as health drops.
        if (gate)
        {
            vPosition.x = 1.1f * ((float)gate.GetComponent<GateScript>().iHealth / (float)gate.GetComponent<GateScript>().iMaxHealth - 1.0f);
            vScale.x = (float)gate.GetComponent<GateScript>().iHealth / (float)gate.GetComponent<GateScript>().iMaxHealth;
        }
        else
        {
            vPosition.x = -1.1f;
            vScale.x = 0.0f;
        }
    }

    private void FixedUpdate()
    {
        greenBar.transform.position = vPosition;
        greenBar.transform.localScale = vScale;
    }
}
