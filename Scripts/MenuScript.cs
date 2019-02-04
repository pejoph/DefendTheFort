//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\
//\                                                                   /\\
//\  Filename: MenuScript.cs         								  /\\
//\  																  /\\
//\  Author  : Peter Phillips										  /\\
//\     															  /\\
//\  Date    : First entry - 15 / 01 / 2018							  /\\
//\     	   Last entry  - 17 / 01 / 2018							  /\\
//\                                                                   /\\
//\  Brief   : Controls menu UI.                                      /\\
//\                                                                   /\\
//\=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=/\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Canvas cMenu;
    public Canvas cHUD;
    public Canvas cCharacterSelect;
    public Canvas cExit;
    public Canvas cOptions;
    public Sprite sNone;
    public Sprite sHuntress;
    public Sprite sSeer;
    public Sprite sHolyKnight;
    public Sprite sStonemason;
    public Image iPlayer1image;
    public Image iPlayer2image;
    public Image iPlayer3image;
    public Image iPlayer4image;
    public Text tPlayer1Text;
    public Text tPlayer2Text;
    public Text tPlayer3Text;
    public Text tPlayer4Text;
    public GameObject gameController;
    public enum PLAYERSELECT
    {
        NONE,
        HUNTRESS,
        SEER,
        HOLYKNIGHT,
        STONEMASON
    }
    public PLAYERSELECT Player1select;
    public PLAYERSELECT Player2select;
    public PLAYERSELECT Player3select;
    public PLAYERSELECT Player4select;

    void Start()
    {
        cHUD.enabled = false;
        cMenu.enabled = true;
        cCharacterSelect.enabled = false;
        cOptions.enabled = false;
        cExit.enabled = false;
        Time.timeScale = 0.0f;
    }

    public void PlayGame()
    {
        cMenu.enabled = false;
        cCharacterSelect.enabled = true;
        iPlayer1image.GetComponent<Image>().sprite = sNone;
        iPlayer2image.GetComponent<Image>().sprite = sNone;
        iPlayer3image.GetComponent<Image>().sprite = sNone;
        iPlayer4image.GetComponent<Image>().sprite = sNone;
        tPlayer1Text.text = "";
        tPlayer2Text.text = "";
        tPlayer3Text.text = "";
        tPlayer4Text.text = "";
        Player1select = PLAYERSELECT.NONE;
        Player2select = PLAYERSELECT.NONE;
        Player3select = PLAYERSELECT.NONE;
        Player4select = PLAYERSELECT.NONE;
    }

    public void Continue()
    {
        cCharacterSelect.enabled = false;
        cHUD.enabled = true;
        Time.timeScale = 1.0f;
        gameController.GetComponent<GameScript>().Start();
    }

    public void Options()
    {
        cOptions.enabled = true;
        cMenu.enabled = false;
    }

    public void Back()
    {
        cMenu.enabled = true;
        cOptions.enabled = false;
        cCharacterSelect.enabled = false;
    }

    public void Exit()
    {
        cExit.enabled = true;
    }

    public void ExitYes()
    {
        Application.Quit();
    }

    public void ExitNo()
    {
        cExit.enabled = false;
    }

    // All below methods scroll through player selection.
    public void P1Right()
    {
        if (iPlayer1image.GetComponent<Image>().sprite == sNone)
        {
            iPlayer1image.GetComponent<Image>().sprite = sHuntress;
            tPlayer1Text.text = "Huntress";
            Player1select = PLAYERSELECT.HUNTRESS;
        }
        else if (iPlayer1image.GetComponent<Image>().sprite == sHuntress)
        {
            iPlayer1image.GetComponent<Image>().sprite = sSeer;
            tPlayer1Text.text = "Seer";
            Player1select = PLAYERSELECT.SEER;
        }
        else if (iPlayer1image.GetComponent<Image>().sprite == sSeer)
        {
            iPlayer1image.GetComponent<Image>().sprite = sHolyKnight;
            tPlayer1Text.text = "Holy Knight";
            Player1select = PLAYERSELECT.HOLYKNIGHT;
        }
        else if (iPlayer1image.GetComponent<Image>().sprite == sHolyKnight)
        {
            iPlayer1image.GetComponent<Image>().sprite = sStonemason;
            tPlayer1Text.text = "Stonemason";
            Player1select = PLAYERSELECT.STONEMASON;
        }
        else
        {
            iPlayer1image.GetComponent<Image>().sprite = sNone;
            tPlayer1Text.text = "";
            Player1select = PLAYERSELECT.NONE;
        }
    }

    public void P1Left()
    {
        if (iPlayer1image.GetComponent<Image>().sprite == sNone)
        {
            iPlayer1image.GetComponent<Image>().sprite = sStonemason;
            tPlayer1Text.text = "Stonemason";
            Player1select = PLAYERSELECT.STONEMASON;
        }
        else if (iPlayer1image.GetComponent<Image>().sprite == sStonemason)
        {
            iPlayer1image.GetComponent<Image>().sprite = sHolyKnight;
            tPlayer1Text.text = "Holy Knight";
            Player1select = PLAYERSELECT.HOLYKNIGHT;
        }
        else if (iPlayer1image.GetComponent<Image>().sprite == sHolyKnight)
        {
            iPlayer1image.GetComponent<Image>().sprite = sSeer;
            tPlayer1Text.text = "Seer";
            Player1select = PLAYERSELECT.SEER;
        }
        else if (iPlayer1image.GetComponent<Image>().sprite == sSeer)
        {
            iPlayer1image.GetComponent<Image>().sprite = sHuntress;
            tPlayer1Text.text = "Huntress";
            Player1select = PLAYERSELECT.HUNTRESS;
        }
        else
        {
            iPlayer1image.GetComponent<Image>().sprite = sNone;
            tPlayer1Text.text = "";
            Player1select = PLAYERSELECT.NONE;
        }
    }

    public void P2Right()
    {
        if (iPlayer2image.GetComponent<Image>().sprite == sNone)
        {
            iPlayer2image.GetComponent<Image>().sprite = sHuntress;
            tPlayer2Text.text = "Huntress";
            Player2select = PLAYERSELECT.HUNTRESS;
        }
        else if (iPlayer2image.GetComponent<Image>().sprite == sHuntress)
        {
            iPlayer2image.GetComponent<Image>().sprite = sSeer;
            tPlayer2Text.text = "Seer";
            Player2select = PLAYERSELECT.SEER;
        }
        else if (iPlayer2image.GetComponent<Image>().sprite == sSeer)
        {
            iPlayer2image.GetComponent<Image>().sprite = sHolyKnight;
            tPlayer2Text.text = "Holy Knight";
            Player2select = PLAYERSELECT.HOLYKNIGHT;
        }
        else if (iPlayer2image.GetComponent<Image>().sprite == sHolyKnight)
        {
            iPlayer2image.GetComponent<Image>().sprite = sStonemason;
            tPlayer2Text.text = "Stonemason";
            Player2select = PLAYERSELECT.STONEMASON;
        }
        else
        {
            iPlayer2image.GetComponent<Image>().sprite = sNone;
            tPlayer2Text.text = "";
            Player2select = PLAYERSELECT.NONE;
        }
    }

    public void P2Left()
    {
        if (iPlayer2image.GetComponent<Image>().sprite == sNone)
        {
            iPlayer2image.GetComponent<Image>().sprite = sStonemason;
            tPlayer2Text.text = "Stonemason";
            Player2select = PLAYERSELECT.STONEMASON;
        }
        else if (iPlayer2image.GetComponent<Image>().sprite == sStonemason)
        {
            iPlayer2image.GetComponent<Image>().sprite = sHolyKnight;
            tPlayer2Text.text = "Holy Knight";
            Player2select = PLAYERSELECT.HOLYKNIGHT;
        }
        else if (iPlayer2image.GetComponent<Image>().sprite == sHolyKnight)
        {
            iPlayer2image.GetComponent<Image>().sprite = sSeer;
            tPlayer2Text.text = "Seer";
            Player2select = PLAYERSELECT.SEER;
        }
        else if (iPlayer2image.GetComponent<Image>().sprite == sSeer)
        {
            iPlayer2image.GetComponent<Image>().sprite = sHuntress;
            tPlayer2Text.text = "Huntress";
            Player2select = PLAYERSELECT.HUNTRESS;
        }
        else
        {
            iPlayer2image.GetComponent<Image>().sprite = sNone;
            tPlayer2Text.text = "";
            Player2select = PLAYERSELECT.NONE;
        }
    }

    public void P3Right()
    {
        if (iPlayer3image.GetComponent<Image>().sprite == sNone)
        {
            iPlayer3image.GetComponent<Image>().sprite = sHuntress;
            tPlayer3Text.text = "Huntress";
            Player3select = PLAYERSELECT.HUNTRESS;
        }
        else if (iPlayer3image.GetComponent<Image>().sprite == sHuntress)
        {
            iPlayer3image.GetComponent<Image>().sprite = sSeer;
            tPlayer3Text.text = "Seer";
            Player3select = PLAYERSELECT.SEER;
        }
        else if (iPlayer3image.GetComponent<Image>().sprite == sSeer)
        {
            iPlayer3image.GetComponent<Image>().sprite = sHolyKnight;
            tPlayer3Text.text = "Holy Knight";
            Player3select = PLAYERSELECT.HOLYKNIGHT;
        }
        else if (iPlayer3image.GetComponent<Image>().sprite == sHolyKnight)
        {
            iPlayer3image.GetComponent<Image>().sprite = sStonemason;
            tPlayer3Text.text = "Stonemason";
            Player3select = PLAYERSELECT.STONEMASON;
        }
        else
        {
            iPlayer3image.GetComponent<Image>().sprite = sNone;
            tPlayer3Text.text = "";
            Player3select = PLAYERSELECT.NONE;
        }
    }

    public void P3Left()
    {
        if (iPlayer3image.GetComponent<Image>().sprite == sNone)
        {
            iPlayer3image.GetComponent<Image>().sprite = sStonemason;
            tPlayer3Text.text = "Stonemason";
            Player3select = PLAYERSELECT.STONEMASON;
        }
        else if (iPlayer3image.GetComponent<Image>().sprite == sStonemason)
        {
            iPlayer3image.GetComponent<Image>().sprite = sHolyKnight;
            tPlayer3Text.text = "Holy Knight";
            Player3select = PLAYERSELECT.HOLYKNIGHT;
        }
        else if (iPlayer3image.GetComponent<Image>().sprite == sHolyKnight)
        {
            iPlayer3image.GetComponent<Image>().sprite = sSeer;
            tPlayer3Text.text = "Seer";
            Player3select = PLAYERSELECT.SEER;
        }
        else if (iPlayer3image.GetComponent<Image>().sprite == sSeer)
        {
            iPlayer3image.GetComponent<Image>().sprite = sHuntress;
            tPlayer3Text.text = "Huntress";
            Player3select = PLAYERSELECT.HUNTRESS;
        }
        else
        {
            iPlayer3image.GetComponent<Image>().sprite = sNone;
            tPlayer3Text.text = "";
            Player3select = PLAYERSELECT.NONE;
        }
    }

    public void P4Right()
    {
        if (iPlayer4image.GetComponent<Image>().sprite == sNone)
        {
            iPlayer4image.GetComponent<Image>().sprite = sHuntress;
            tPlayer4Text.text = "Huntress";
            Player4select = PLAYERSELECT.HUNTRESS;
        }
        else if (iPlayer4image.GetComponent<Image>().sprite == sHuntress)
        {
            iPlayer4image.GetComponent<Image>().sprite = sSeer;
            tPlayer4Text.text = "Seer";
            Player4select = PLAYERSELECT.SEER;
        }
        else if (iPlayer4image.GetComponent<Image>().sprite == sSeer)
        {
            iPlayer4image.GetComponent<Image>().sprite = sHolyKnight;
            tPlayer4Text.text = "Holy Knight";
            Player4select = PLAYERSELECT.HOLYKNIGHT;
        }
        else if (iPlayer4image.GetComponent<Image>().sprite == sHolyKnight)
        {
            iPlayer4image.GetComponent<Image>().sprite = sStonemason;
            tPlayer4Text.text = "Stonemason";
            Player4select = PLAYERSELECT.STONEMASON;
        }
        else
        {
            iPlayer4image.GetComponent<Image>().sprite = sNone;
            tPlayer4Text.text = "";
            Player4select = PLAYERSELECT.NONE;
        }
    }

    public void P4Left()
    {
        if (iPlayer4image.GetComponent<Image>().sprite == sNone)
        {
            iPlayer4image.GetComponent<Image>().sprite = sStonemason;
            tPlayer4Text.text = "Stonemason";
            Player4select = PLAYERSELECT.STONEMASON;
        }
        else if (iPlayer4image.GetComponent<Image>().sprite == sStonemason)
        {
            iPlayer4image.GetComponent<Image>().sprite = sHolyKnight;
            tPlayer4Text.text = "Holy Knight";
            Player4select = PLAYERSELECT.HOLYKNIGHT;
        }
        else if (iPlayer4image.GetComponent<Image>().sprite == sHolyKnight)
        {
            iPlayer4image.GetComponent<Image>().sprite = sSeer;
            tPlayer4Text.text = "Seer";
            Player4select = PLAYERSELECT.SEER;
        }
        else if (iPlayer4image.GetComponent<Image>().sprite == sSeer)
        {
            iPlayer4image.GetComponent<Image>().sprite = sHuntress;
            tPlayer4Text.text = "Huntress";
            Player4select = PLAYERSELECT.HUNTRESS;
        }
        else
        {
            iPlayer4image.GetComponent<Image>().sprite = sNone;
            tPlayer4Text.text = "";
            Player4select = PLAYERSELECT.NONE;
        }
    }
}
