using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMaster : MonoBehaviour
{


    [SerializeField] private Vector2 lastCheckpoint;

    public int level=1;
    public int lastCheckpointNum = 0;


    [SerializeField] public GameObject[] checkPoints;

    [SerializeField] private Finish finish;

    public float levelTimer =0;

    public bool isDying = false;
    public bool onMenu = true;

    void Awake()
    {
        LoadPlayer();
    }
    private void Start()
    {
        


       
    }

    public void SetCheckpoint(int checkpointNum)
    {
        if (!isDying)
        {
            lastCheckpointNum = checkpointNum;
            levelTimer += finish.levelTimer;
            finish.levelTimer = 0;
            SavePlayer();
        }

    }
    public Vector2 GetCheckpoint()
    {
        return checkPoints[lastCheckpointNum].transform.position;
    }

    public int GetCheckpointNum()
    {
        return lastCheckpointNum;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        
        GameData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            level = data.level;
            lastCheckpointNum = data.checkpointNum;
            levelTimer = data.levelTimer;
        }
    }


    public bool isPlayerStop()
    {
        return isDying || onMenu;

    }

    private void OnApplicationQuit()
    {
        if(finish != null)
        levelTimer += finish.levelTimer;
        SavePlayer();
    }
}
