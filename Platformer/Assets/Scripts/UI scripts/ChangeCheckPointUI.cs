using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCheckPointUI : MonoBehaviour
{
    private bool forOnce=false;

    [SerializeField] private GameObject checkpoint;

    private GameObject[] UIcheckpoints;

    private GameMaster gm;
    private void Update()
    {
        if (!forOnce)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            UIcheckpoints = new GameObject[gm.checkPoints.Length];
            for (int i = 1; i < UIcheckpoints.Length; i++)
            {
                UIcheckpoints[i] =Instantiate(checkpoint, checkpoint.transform.position + i * new Vector3(50f, 0, 0), Quaternion.identity, transform);
            }
            forOnce = true;
                
        }


    }

}
