using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Vector3 startScale;
    private Vector3 startPosition;
    private void Start()
    {
        startScale = transform.localScale;
        startPosition = transform.localPosition;
    }



    public void OpenDoor()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, 0.1f,transform.localScale.z), 0.01f);
        transform.localPosition = new Vector3(transform.localPosition.x,startPosition.y + 2*(startScale.y - transform.localScale.y), transform.localPosition.z);
    }
    public void CloseDoor()
    {
        transform.localScale = Vector3.Lerp(transform.localScale,startScale, 0.01f);

        transform.localPosition = new Vector3(transform.localPosition.x, startPosition.y + 2 * (startScale.y - transform.localScale.y), transform.localPosition.z);
    }
}
