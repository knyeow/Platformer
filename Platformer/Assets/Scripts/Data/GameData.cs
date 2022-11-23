using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]  //able to save it in a file
public class GameData
{
    private float checkPointPosX;
    private float checkPointPosY;

    public float levelTimer =0;

    public GameData (GameMaster gameMaster)
    {
        checkPointPosX = gameMaster.GetCheckpoint().x;
        checkPointPosY = gameMaster.GetCheckpoint().y;
        levelTimer = gameMaster.levelTimer;
    }

    public Vector2 GetCheckpoint()
    {
        return new Vector2(checkPointPosX,checkPointPosY);
    }
}
