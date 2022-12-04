using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHat : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private GameObject hat;
    [SerializeField] private Transform playerHatPos;
    
    [SerializeField] private float powerFactor;

    
    private Vector3 mousePos;
    private Camera mainCamera;

    private Rigidbody2D rb;
    private Hat hatHat;

    

    [SerializeField] private Transform pointsPos;
    [SerializeField] private GameObject point;
    private GameObject[] points;
    int currentPointNumber = 0;

    private GameMaster gm;

    private Vector2 gamepadAxis;



    public bool isGamepad;
    void Start()
    {
        player = GetComponent<Player>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        rb = GetComponent<Rigidbody2D>();
        hatHat = hat.GetComponent<Hat>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        points = new GameObject[15];
        Physics2D.IgnoreLayerCollision(8, 9);
    }

   
   private  void Update()
    {
        


        if (gm.isPlayerStop()) return;


        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        gamepadAxis = new Vector2(Input.GetAxis("Gamepad X"), Input.GetAxis("Gamepad Y"));



        if (Input.GetButton("Fire1") && !hatHat.isThrow)            //hat aim
            {
                Vector2 rotation = mousePos - pointsPos.position;
            float rotZ;
            if (!isGamepad)
                rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            else
                rotZ = Mathf.Atan2(gamepadAxis.y, gamepadAxis.x) * Mathf.Rad2Deg;

                pointsPos.transform.rotation = Quaternion.Euler(0, 0, rotZ);
                int pointsNumber = Mathf.Min((Mathf.Abs((int)ThrowPower().x) + Mathf.Abs((int)ThrowPower().y)), 15);


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


                while (currentPointNumber != pointsNumber)
                {
                    Destroy(points[currentPointNumber - 1]);
                    currentPointNumber--;

                }


            }
            if (Input.GetButtonUp("Fire1"))              //throw hat
            {
                if (!hatHat.isThrow)
                    hatHat.ThrowHat(ThrowPower());

                for (int i = 0; i < points.Length; i++)
                {
                    Destroy(points[i]);
                }
                currentPointNumber = 0;

            }

            if (Input.GetButton("Button 1") && hatHat.isThrow)   //take hat back
            {
                hatHat.TakeHatBack();

            }



            if (Input.GetButton("Button 2") && hatHat.Teleportable())       //teleport
            {
                Teleport();
                hatHat.isThrow = false;
                hatHat.TakeHatBack();
            }

        
      
        

    }

    private void Teleport()
    {
        transform.position = hat.transform.position+new Vector3(0,+0.5f+0);
        rb.velocity = hat.GetComponent<Rigidbody2D>().velocity;
        player.clearTrails();
    }


    private  Vector2 ThrowPower()
    {
        Vector2 throwPower,limitedRotation;


        Vector2 rotation = mousePos - pointsPos.position;
        Vector2 signedRotation = new Vector2(Mathf.Sign(rotation.x), Mathf.Sign(rotation.y));
        limitedRotation = new Vector2(Mathf.Min(Mathf.Abs(rotation.x),10),Mathf.Min(Mathf.Abs(rotation.y),10));

        if(!isGamepad)
        throwPower = limitedRotation * powerFactor*signedRotation;
        else
        throwPower = (new Vector2(Input.GetAxis("Gamepad X"), Input.GetAxis("Gamepad Y")))*powerFactor*10;
        

        return throwPower;


    }

    public void DeletePoints()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Destroy(points[i]);
        }
        currentPointNumber = 0;
    }

}


