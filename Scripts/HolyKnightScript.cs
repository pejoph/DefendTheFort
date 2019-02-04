//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: HolyKnightScript.cs									  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 15 / 01 / 2018							  /\\
//\     	   Last entry  - 17 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Script for moving the player and attacking using       /\\
//\            Unity's input mapped controls.                         /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyKnightScript : MonoBehaviour
{
    public float fPlayerSpeed;
    public GameObject trail;
    public float fSwingRate;
    public GameObject sword;
    public Transform tTrailPos;
    public GameObject swordSweepPos;
    public GameObject swordOrigPos;
    public Transform tPlayer1Spawn;
    public Transform tPlayer2Spawn;
    public Transform tPlayer3Spawn;
    public Transform tPlayer4Spawn;

    private float fHorizontal;
    private float fVertical;
    private float fFireInterval = 0.0f;
    private Vector2 vMovementDirection;
    private bool bJoystick = false;
    private enum CONTROLLERSELECT
    {
        PLAYER1,
        PLAYER2,
        PLAYER3,
        PLAYER4
    }
    private CONTROLLERSELECT controller;

    void Start()
    {
        // Determines which controller controls character based on where character spawns.
        if (transform.position == tPlayer1Spawn.transform.position)
        {
            controller = CONTROLLERSELECT.PLAYER1;
        }
        else if (transform.position == tPlayer2Spawn.transform.position)
        {
            controller = CONTROLLERSELECT.PLAYER2;
        }
        else if (transform.position == tPlayer3Spawn.transform.position)
        {
            controller = CONTROLLERSELECT.PLAYER3;
        }
        else if (transform.position == tPlayer4Spawn.transform.position)
        {
            controller = CONTROLLERSELECT.PLAYER4;
        }
    }

    private void Update()
    {
        if (controller == CONTROLLERSELECT.PLAYER1)
        {
            if (!(Input.GetAxisRaw("Fire1") == 0 && Input.GetAxisRaw("Fire1alt") == 0) || !(Input.GetAxisRaw("Horizontal1") == 0 && Input.GetAxisRaw("Vertical1") == 0))
            {
                bJoystick = true;
            }
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                bJoystick = false;
            }
            if (bJoystick)
            {
                if (!(Input.GetAxisRaw("Fire1") == 0 && Input.GetAxisRaw("Fire1alt") == 0))
                {
                    transform.up = new Vector2(Input.GetAxisRaw("Fire1"), Input.GetAxisRaw("Fire1alt"));
                }
            }
            else
            {
                // Rotate player so that player faces the curser.
                // Input.mousePosition gives the mouse position in pixels from the bottom left corner of the screen 
                // so I had to convert the world position of the player into a pixel position in order to centre 
                // the rotation about the player.
                transform.up = new Vector2(Input.mousePosition.x - Screen.width / 2.0f * (1.0f + transform.position.x / (5.0f * 16.0f / 9.0f)),
                                                   Input.mousePosition.y - Screen.height / 2.0f * (1.0f + transform.position.y / 5.0f));
            }

            // When LMB is held down, fire every 1 / fire rate seconds.
            if ((Input.GetButton("Fire") || Input.GetAxisRaw("Fire1") != 0 || Input.GetAxisRaw("Fire1alt") != 0) && Time.time >= fFireInterval)
            {
                Sweep();
                fFireInterval = Time.time + 1.0f / fSwingRate;
            }
        }
        else if (controller == CONTROLLERSELECT.PLAYER2)
        {
            if (!(Input.GetAxisRaw("Fire2") == 0 && Input.GetAxisRaw("Fire2alt") == 0))
            {
                transform.up = new Vector2(Input.GetAxisRaw("Fire2"), Input.GetAxisRaw("Fire2alt"));
            }

            if ((Input.GetAxisRaw("Fire2") != 0 || Input.GetAxisRaw("Fire2alt") != 0) && Time.time >= fFireInterval)
            {
                Sweep();
                fFireInterval = Time.time + 1.0f / fSwingRate;
            }
        }
        else if (controller == CONTROLLERSELECT.PLAYER3)
        {
            if (!(Input.GetAxisRaw("Fire3") == 0 && Input.GetAxisRaw("Fire3alt") == 0))
            {
                transform.up = new Vector2(Input.GetAxisRaw("Fire3"), Input.GetAxisRaw("Fire3alt"));
            }

            if ((Input.GetAxisRaw("Fire3") != 0 || Input.GetAxisRaw("Fire3alt") != 0) && Time.time >= fFireInterval)
            {
                Sweep();
                fFireInterval = Time.time + 1.0f / fSwingRate;
            }
        }
        else if (controller == CONTROLLERSELECT.PLAYER4)
        {
            if (!(Input.GetAxisRaw("Fire4") == 0 && Input.GetAxisRaw("Fire4alt") == 0))
            {
                transform.up = new Vector2(Input.GetAxisRaw("Fire4"), Input.GetAxisRaw("Fire4alt"));
            }

            if ((Input.GetAxisRaw("Fire4") != 0 || Input.GetAxisRaw("Fire4alt") != 0) && Time.time >= fFireInterval)
            {
                Sweep();
                fFireInterval = Time.time + 1.0f / fSwingRate;
            }
        }
    }

    private void FixedUpdate()
    {
        if (controller == CONTROLLERSELECT.PLAYER1)
        {
            // Get the horizontal and vertical movements components from user input.
            // The square root part stops the player from moving faster when going diagonally.
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                fHorizontal = Input.GetAxisRaw("Horizontal") * Mathf.Sqrt(1.0f - Mathf.Abs(Input.GetAxisRaw("Vertical")) / 2.0f);
                fVertical = Input.GetAxisRaw("Vertical") * Mathf.Sqrt(1.0f - Mathf.Abs(Input.GetAxisRaw("Horizontal")) / 2.0f);
            }
            else
            {
                fHorizontal = Input.GetAxisRaw("Horizontal1");
                fVertical = Input.GetAxisRaw("Vertical1");
            }
            vMovementDirection = new Vector2(fHorizontal, fVertical);
            // Update the player's velocity using our direction vector and speed value.
            GetComponent<Rigidbody2D>().velocity = fPlayerSpeed * vMovementDirection;
        }
        else if (controller == CONTROLLERSELECT.PLAYER2)
        {
            fHorizontal = Input.GetAxisRaw("Horizontal2");
            fVertical = Input.GetAxisRaw("Vertical2");
            vMovementDirection = new Vector2(fHorizontal, fVertical);
            GetComponent<Rigidbody2D>().velocity = fPlayerSpeed * vMovementDirection;
        }
        else if (controller == CONTROLLERSELECT.PLAYER3)
        {
            fHorizontal = Input.GetAxisRaw("Horizontal3");
            fVertical = Input.GetAxisRaw("Vertical3");
            vMovementDirection = new Vector2(fHorizontal, fVertical);
            GetComponent<Rigidbody2D>().velocity = fPlayerSpeed * vMovementDirection;
        }
        else if (controller == CONTROLLERSELECT.PLAYER4)
        {
            fHorizontal = Input.GetAxisRaw("Horizontal4");
            fVertical = Input.GetAxisRaw("Vertical4");
            vMovementDirection = new Vector2(fHorizontal, fVertical);
            GetComponent<Rigidbody2D>().velocity = fPlayerSpeed * vMovementDirection;
        }
    }

    public void Sweep()
    {
        sword.transform.position = swordSweepPos.transform.position;
        sword.transform.eulerAngles = swordSweepPos.transform.eulerAngles;
        // Swings the sword.
        GameObject currentTrail = Instantiate(trail, tTrailPos);
        // Destroy trail object after 0.5 seconds.
        Destroy(currentTrail, .2f);
        StartCoroutine(SwordSweep());
    }

    public IEnumerator SwordSweep()
    {
        yield return new WaitForSeconds(.2f);
        sword.transform.position = swordOrigPos.transform.position;
        sword.transform.eulerAngles = swordOrigPos.transform.eulerAngles;
    }
}
