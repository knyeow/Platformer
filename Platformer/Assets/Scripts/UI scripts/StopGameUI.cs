using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGameUI : MonoBehaviour
{
    [SerializeField] private GameObject controls;


    private GameMaster gm;


    public void OpenUI()
    {
        gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>().onMenu = true;
        Time.timeScale = 0;
    }
    public void CloseUI()
    {
        StartCoroutine(CoCloseUI());
    }
    public void CloseApp()
    {
        Application.Quit();       
    }

    public void Controls()
    {
        if(controls.activeInHierarchy)
            controls.SetActive(false);
        else
            controls.SetActive(true);
    }

    IEnumerator CoCloseUI()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.1f);
        GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>().onMenu = false;
        controls.SetActive(false);
        gameObject.SetActive(false);
    }

}
