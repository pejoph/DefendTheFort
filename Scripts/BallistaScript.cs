//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: BallistaScript.cs									  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 16 / 01 / 2018							  /\\
//\     	   Last entry  - 16 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Ballistae break when they run out of ammo.             /\\
//\                                                                   /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaScript : MonoBehaviour
{
    public GameObject bolt;
    public Transform tBallista;
    public int iAmmo;
    public int iMaxAmmo;
    public bool bIsBroken;
    public GameObject broken;
    public int iHealth;
    public int iMaxHealth;

    private float fFireRate = .25f;
    private float fRange = 2.0f;
    private float fFireInterval = 0.0f;

    void Start ()
    {
        bIsBroken = true;
    }

	void Update ()
    {
        if (iAmmo > 0 && Time.time >= fFireInterval && !bIsBroken)
        {
            Shoot();
            fFireInterval = Time.time + 1.0f / fFireRate;
            iAmmo -= 1;
        }
        else if (iAmmo == 0 && Time.time >= fFireInterval && !bIsBroken)
        {
            bIsBroken = true;
            iHealth = 0;
            broken.GetComponent<SpriteRenderer>().color = new Color(128.0f / 255.0f, 64.0f / 255.0f, 64.0f / 255.0f, 176.0f / 255.0f);
        }
    }

    public void Shoot()
    {
        // Creates a bolt from our prefabs and gives it the position and rotation of the ballista.
        GameObject currentBolt = Instantiate(bolt, tBallista);
        // Remove the ballista as the parent so the bolt can move irrespective of the ballista.
        currentBolt.transform.parent = null;
        // Destroy bolt object after a time determined by the range.
        Destroy(currentBolt, fRange);
    }
}
