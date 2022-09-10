using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]  //able to save it in a file
public class PlayerData
{
    public int deathCount;

    public PlayerData (Player player)
    {
        deathCount = player.deathCount;
    }

}
