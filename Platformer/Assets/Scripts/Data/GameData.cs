using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]  //able to save it in a file
public class GameData
{
    public int level = 1;
    public int checkpointNum;

    public float levelTimer =0;

    public GameData (GameMaster gameMaster)
    {
        level = gameMaster.level;
        checkpointNum = gameMaster.lastCheckpointNum;
        levelTimer = gameMaster.levelTimer;
    }

}
