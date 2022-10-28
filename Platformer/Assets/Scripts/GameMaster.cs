using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;

    [SerializeField] private Vector2 lastCheckpoint;

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

    public void SetCheckpoint(Vector2 checkpointPosition)
    {
        lastCheckpoint = checkpointPosition;
    }
    public Vector2 GetCheckpoint()
    {
        return lastCheckpoint;
    }
}
