using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


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
            gm.level++;
            gm.lastCheckpointNum = 0;
            gm.SavePlayer();
            forOnce = true;
        }



    }

    public void CloseApp()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadSceneAsync(gm.level));
    }

    IEnumerator LoadSceneAsync(int sceneID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);


        while (!operation.isDone)
        {
            yield return null;
        }
    }

}
