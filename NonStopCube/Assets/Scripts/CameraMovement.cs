using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float lerp;
   
    // Update is called once per frame
    void Update()
    {
        Follow();
    }
    private void Follow()
    {
        Vector3 smoothPoint = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x,player.transform.position.y,-10), lerp*Time.deltaTime);
        transform.position = smoothPoint;
    }

}
