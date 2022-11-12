using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;

    [SerializeField] private Vector2 lastCheckpoint;
    [SerializeField] private int currentCheckpointNum;


    [SerializeField] public GameObject[] checkPoints;

    public bool isDying = false;
    public bool onMenu = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);

        
    }
    private void Start()
    {
        checkPoints = new GameObject[GameObject.FindGameObjectsWithTag("Checkpoint").Length];
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Checkpoint").Length; i++)
        {

            checkPoints[GameObject.FindGameObjectsWithTag("Checkpoint")[i].GetComponent<CheckPoint>().checkpointNum]
                = GameObject.FindGameObjectsWithTag("Checkpoint")[i];
        }
        LoadPlayer();
    }

    public void SetCheckpoint(Vector2 checkpointPosition)
    {
        if (!isDying)
        {
            lastCheckpoint = checkpointPosition;
            SavePlayer();
        }

    }
    public Vector2 GetCheckpoint()
    {
        return lastCheckpoint;
    }


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        GameData data = SaveSystem.LoadPlayer();
        SetCheckpoint(data.GetCheckpoint());
    }


    public bool isPlayerStop()
    {
        return isDying || onMenu;

    }
}
