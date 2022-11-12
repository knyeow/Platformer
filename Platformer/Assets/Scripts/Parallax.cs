using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private float parallaxEffectMultiplier;

    [SerializeField]
    private float parallaxEffectMultiplierY;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    #endregion

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }
    #region Functions
    private void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier, deltaMovement.y * parallaxEffectMultiplierY);
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) > 39.1837f)
            transform.position = new Vector2(cameraTransform.position.x, transform.position.y);


    }
    #endregion


}
