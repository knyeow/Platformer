using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGameUI : MonoBehaviour
{
    private GameMaster gm;

    [SerializeField] private GameObject checkpointUI;

    public void OpenUI()
    {
        gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>().onMenu = true;
        Time.timeScale = 0;
    }
    public void CloseUI()
    {
        GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>().onMenu = false;
        Time.timeScale = 1;
        checkpointUI.SetActive(false);
        gameObject.SetActive(false);
    }
    public void CloseApp()
    {
        Application.Quit();       
    }


    public void OpenCheckpointUI()
    {
        checkpointUI.SetActive(true);
    }

}
