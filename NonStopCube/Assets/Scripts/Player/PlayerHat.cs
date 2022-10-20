using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHat : MonoBehaviour
{
    [SerializeField] private GameObject hat;
    [SerializeField] private Transform playerHatPos;
    
    [SerializeField] private float powerFactor;

    
    [SerializeField] private GameObject lookAtMouse;

    private Vector3 mousePos;
    private Camera mainCamera;

    private Rigidbody2D rb;
    private Hat hatHat;


    [SerializeField] private Transform pointsPos;
    [SerializeField] private GameObject point;
    private GameObject[] points;
    int currentPointNumber = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hatHat = hat.GetComponent<Hat>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        points = new GameObject[15];
    }

   
   private  void Update()
    {
        Physics2D.IgnoreLayerCollision(8, 9);

        Vector2 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;





        
        if (Input.GetMouseButton(0) && !hatHat.isThrow)            //hat aim
        {
            pointsPos.transform.rotation = Quaternion.Euler(0, 0, rotZ);
            int pointsNumber = Mathf.Min((Mathf.Abs((int)ThrowPower().x) + Mathf.Abs((int)ThrowPower().y)),15);


            if (Mathf.Sign(transform.localScale.x) < 0)
                pointsPos.transform.localScale = new Vector2(-1, pointsPos.transform.localScale.y);
            else
                pointsPos.transform.localScale = new Vector2(1, pointsPos.transform.localScale.y);

            
                for (int i = 0; i < pointsNumber; i++)
                {
                    if (points[i] == null)
                    {
                        points[i] = Instantiate(point, playerHatPos.position, Quaternion.identity, pointsPos);
                        points[i].transform.localPosition = new Vector2(i * 0.2f, 0f);
                    currentPointNumber++;
                    }
                }
            
            for (int i = 0;i < currentPointNumber-pointsNumber; i++)
            {   
                Destroy(points[currentPointNumber - i-1]);
                currentPointNumber--;
            }
            
        }
        if (Input.GetMouseButtonUp(0))              //throw hat
        {
            if (!hatHat.isThrow)
                hatHat.ThrowHat(ThrowPower());

            for (int i = 0; i < points.Length; i++)
            {
                Destroy(points[i]);
            }
            currentPointNumber = 0;
           
        }
        if (Input.GetKey(KeyCode.Q) && hatHat.isThrow)   //take hat back
        {
            hatHat.TakeHatBack();
            
        }

        

        if (Input.GetKey(KeyCode.E) && hatHat.Teleportable())       //teleport
        {
            Teleport();
            hatHat.isThrow = false;
            hatHat.TakeHatBack();
        }

      
        

    }

    private void Teleport()
    {
        transform.position = hat.transform.position+new Vector3(0,+0.3f+0);
        rb.velocity = Vector2.zero;
    }


    private  Vector2 ThrowPower()
    {
        Vector2 throwPower,limitedRotation;


        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rotation = mousePos - transform.position;
        Vector2 signedRotation = new Vector2(Mathf.Sign(rotation.x), Mathf.Sign(rotation.y));

        limitedRotation = new Vector2(Mathf.Min(Mathf.Abs(rotation.x),10),Mathf.Min(Mathf.Abs(rotation.y),10));
        throwPower = limitedRotation * powerFactor*signedRotation;

        return throwPower;


    }
    private void PlankSize()                //not currently using" its changing planks size according to mouseposisition
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rotation = mousePos - playerHatPos.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        lookAtMouse.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        lookAtMouse.transform.localScale = new Vector2(Mathf.Min(Mathf.Sqrt(Mathf.Pow(rotation.x, 2) + Mathf.Pow(rotation.y, 2)) / 3, 3), lookAtMouse.transform.localScale.y);
        lookAtMouse.transform.localPosition = new Vector2(lookAtMouse.transform.localScale.x / 2, lookAtMouse.transform.localPosition.y);
    }
}


