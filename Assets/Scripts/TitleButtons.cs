using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtons : MonoBehaviour
{
    public void ClickOnStart()
    {
        GameManager.Instance.OnClickStart();
    }

    public void ClickOnNewGame()
    {
        GameManager.Instance.OnClickStart();
    }

    public void ClickOnQuit()
    {
        Application.Quit();
    }
}
