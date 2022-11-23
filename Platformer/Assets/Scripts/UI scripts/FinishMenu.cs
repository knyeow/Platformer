using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text levelTimer;

    private GameMaster gm;

    private bool forOnce = false;

    private int[] time = new int[4];

    private void Update()
    {
        if (!forOnce)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            time[1] = (int)gm.levelTimer / 60;
            time[0] = (int)time[1] / 60;
            time[2] = (int)(gm.levelTimer - time[1] * 60);
            levelTimer.text = (time[0] + "h" + time[1] + "m" + time[2] + "s");
            forOnce = true;
        }
    }

    public void CloseApp()
    {
        Application.Quit();
    }

}
