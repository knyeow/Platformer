using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MainMenu : MonoBehaviour
{
    private GameMaster gm;

    [SerializeField] private GameObject loadGameText;

    private Animator anim;

    private string savePath;


    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        anim = GetComponent<Animator>();
        savePath = Application.persistentDataPath + "/player.data";

        if (File.Exists(savePath))
        {
            var tempColor = loadGameText.GetComponent<TMPro.TMP_Text>().color;
            tempColor.a = 1f;
            loadGameText.GetComponent<TMPro.TMP_Text>().color = tempColor;
            loadGameText.GetComponent<Button>().enabled = true;
        }

    }

    public void Play()
    {
        anim.SetBool("play", true);
    }


    public void LoadScene()
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


    public void CloseApp()
    {
        Application.Quit();
    }


    public void NewGame()
    {
        if (File.Exists(savePath))
            File.Delete(savePath);
        gm.level = 1;
        anim.SetBool("play", true);

    }
    public void LoadGame()
    {
        anim.SetBool("play", true);
    }

}
