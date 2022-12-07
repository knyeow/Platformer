using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKit : MonoBehaviour
{
    [SerializeField] private GameObject checkpointButton;
    private GameMaster gm;

    private bool forOnce = false;
    private void Update()
    {
        if (!forOnce)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            for(int i = 1; i< gm.checkPoints.Length; i++)
            {
                checkpointButton = Instantiate(checkpointButton,transform);
                checkpointButton.GetComponent<TestkitButton>().checkpointNum = i;
                checkpointButton.transform.position += new Vector3(60*i, 0,0);
                
            }
            forOnce = true;
        }
    }
}
