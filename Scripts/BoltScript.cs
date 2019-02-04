//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: BoltScript.cs	  									  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 16 / 01 / 2018							  /\\
//\     	   Last entry  - 16 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Moves bolt projectile and damages enemy on collision.  /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
    private Transform tDirection;
    private float fRand;
    private float fOffset = 30.0f;
    private float fSpeed = 0.1f;

    void Start()
    {
        // Seed the random number with the current time.
        Random.InitState(System.DateTime.Now.Millisecond);
        // Generate a number between -1 and 1.
        fRand = Random.Range(-1.0f, 1.0f);
        // Square the magnitude of this number so that the range is the same but on average the shots are more accurate.
        fRand = Mathf.Pow(fRand, 2.0f) * fRand / Mathf.Abs(fRand);
        // Initialise the direction with that of the bolt.
        tDirection = transform;
        // Rotate bolt according the offset value and the random number.
        tDirection.transform.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z + fOffset * fRand);
    }

    private void FixedUpdate()
    {
        // Move bolt in calculated direction.
        transform.position += tDirection.up * fSpeed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<GoblinScript>().DamageReceived(80);

        }
    }
}
