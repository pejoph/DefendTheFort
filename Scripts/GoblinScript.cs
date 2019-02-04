//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: GoblinScript.cs 			        					  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 15 / 01 / 2018							  /\\
//\     	   Last entry  - 19 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Controls goblins.                                      /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    private int iHealth;
    private Color originalColour;
    private float fSpeed;
    private float fRandom;
    private Color cColour;

    void Start ()
    {
        // Position within spawn area is randomised.
        transform.position = new Vector2(transform.position.x + Random.Range(-.8f, .8f), transform.position.y + Random.Range(-.8f, .8f));
        // Health, colour and speed are randomised but proportional to one another.
        fRandom = Random.Range(-1.0f, 1.0f);
        iHealth = 100 + (int)(50 * fRandom);
        GetComponentInChildren<SpriteRenderer>().color = Color.HSVToRGB(((55.0f + 20.0f * fRandom)  / 255.0f), (255.0f / 255.0f), ((134.0f - 20.0f * fRandom) / 255.0f));
        originalColour = GetComponentInChildren<SpriteRenderer>().color;
        fSpeed = .02f - .01f * fRandom;
    }
	
	void Update ()
    {
        // Kill goblin and increase score.
        if (iHealth <= 0)
        {
            Destroy(gameObject);
            GameOverScript.iScore += 1;
        }
	}

    private void FixedUpdate()
    {
        // Move goblin towards centre.
        transform.position -= transform.up * fSpeed;
    }

    public void DamageReceived(int dmg)
    {
        // Goblin loses health on hit.
        iHealth -= dmg;

        StartCoroutine(ColourChange());
    }

    public IEnumerator ColourChange()
    {
        // Goblin turns red briefly then turns back to original colour.
        GetComponentInChildren<SpriteRenderer>().color = new Color(200.0f / 255.0f, 25.0f / 255.0f, 0.0f);
        yield return new WaitForSeconds(.1f);
        GetComponentInChildren<SpriteRenderer>().color = originalColour;
    }
}
