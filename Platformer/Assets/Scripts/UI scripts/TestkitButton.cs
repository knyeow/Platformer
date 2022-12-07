using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestkitButton : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public int checkpointNum;
    private GameMaster gm;
    private Player player;
    private bool forOnce=false;



    private void Update()
    {
        if (!forOnce)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            text.text = checkpointNum.ToString();
            forOnce = true;
        }

        if (gm.GetCheckpointNum() == checkpointNum)
            GetComponent<Image>().color = Color.yellow;
        else
            GetComponent<Image>().color = Color.white;
    }


    public void ChangeCheckpoint()
    {
        gm.SetCheckpoint(checkpointNum);
        player.Die();
    }




}
