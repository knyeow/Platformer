using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{

    [SerializeField]private StopGameUI stopGameUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            if(!stopGameUI.gameObject.activeInHierarchy)
                stopGameUI.OpenUI();
            else
                stopGameUI.CloseUI();



    }



}
