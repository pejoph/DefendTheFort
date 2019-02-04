//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: ArrowScript.cs										  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 13 / 01 / 2018							  /\\
//\     	   Last entry  - 15 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Moves arrow projectile and damages enemy on            /\\
//\            collision.                                             /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float fSpeed = 0.1f;
    public float fOffset = 15.0f;
    public GameObject huntress;
    public int iPiercing;

    private Transform tDirection;
    private float fRand;
    
	void Start ()
    {
        // Seed the random number with the current time.
        Random.InitState(System.DateTime.Now.Millisecond);
        // Generate a number between -1 and 1.
        fRand = Random.Range(-1.0f, 1.0f);
        // Square the magnitude of this number so that the range is the same but on average the shots are more accurate.
        fRand = Mathf.Pow(fRand, 2.0f) * fRand/Mathf.Abs(fRand);
        // Initialise the direction with that of the arrow.
        tDirection = transform;
        // Rotate arrow according the offset value and the random number.
        tDirection.transform.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z + fOffset * fRand);
	}

	void Update ()
    {
        if (iPiercing < 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        // Move arrow in calculated direction.
        transform.position += tDirection.up * fSpeed;
    }     

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Reduces number of enemies arrow can pierce upon each hit.
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<GoblinScript>().DamageReceived(20);
            iPiercing -= 1;
        }
    }  
}
