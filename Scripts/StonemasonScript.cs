//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: StonemasonScript.cs      							  /\\
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

public class StonemasonScript : MonoBehaviour
{
    public float fPlayerSpeed;
    public GameObject hammer;
    public Transform tHamPos1;
    public Transform tHamPos2;
    public Transform tHamPos3;
    public Transform tHamPos4;
    public Transform tHamPos5;
    public Transform tHamPos6;
    public Transform tHamPos7;
    public Transform tHamPos8;
    public Transform tHamPos9;
    public Transform tHamPos10;
    public Transform tHamPos11;
    public Transform tHamPos12;
    public float fSwingRate;
    public GameObject trail;
    public Transform tRepairPos;
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
                Repair();
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
                Repair();
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
                Repair();
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
                Repair();
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

    public void Repair()
    {
        GameObject currentTrail = Instantiate(trail, tRepairPos);
        // Destroy trail object after 2/3 seconds.
        Destroy(currentTrail, 2.0f / 3.0f);
        StartCoroutine(HammerSwing());
    }

    public IEnumerator HammerSwing()
    {
        hammer.transform.position = tHamPos2.position;
        hammer.transform.eulerAngles = tHamPos2.eulerAngles;
        yield return new WaitForSeconds(.05f);
        hammer.transform.position = tHamPos3.position;
        hammer.transform.eulerAngles = tHamPos3.eulerAngles;
        yield return new WaitForSeconds(.05f);
        hammer.transform.position = tHamPos4.position;
        hammer.transform.eulerAngles = tHamPos4.eulerAngles;
        yield return new WaitForSeconds(.05f);
        hammer.transform.position = tHamPos5.position;
        hammer.transform.eulerAngles = tHamPos5.eulerAngles;
        yield return new WaitForSeconds(.05f);
        hammer.transform.position = tHamPos6.position;
        hammer.transform.eulerAngles = tHamPos6.eulerAngles;
        yield return new WaitForSeconds(.05f);
        hammer.transform.position = tHamPos7.position;
        hammer.transform.eulerAngles = tHamPos7.eulerAngles;
        yield return new WaitForSeconds(.05f);
        hammer.transform.position = tHamPos8.position;
        hammer.transform.eulerAngles = tHamPos8.eulerAngles;
        yield return new WaitForSeconds(.05f);
        hammer.transform.position = tHamPos9.position;
        hammer.transform.eulerAngles = tHamPos9.eulerAngles;
        yield return new WaitForSeconds(.05f);
        hammer.transform.position = tHamPos10.position;
        hammer.transform.eulerAngles = tHamPos10.eulerAngles;
        yield return new WaitForSeconds(.05f);
        hammer.transform.position = tHamPos11.position;
        hammer.transform.eulerAngles = tHamPos11.eulerAngles;
        yield return new WaitForSeconds(.05f);
        hammer.transform.position = tHamPos12.position;
        hammer.transform.eulerAngles = tHamPos12.eulerAngles;
        yield return new WaitForSeconds(.05f);
        hammer.transform.position = tHamPos1.position;
        hammer.transform.eulerAngles = tHamPos1.eulerAngles;
        yield return new WaitForSeconds(.05f);
    }
}
