using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatesails : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 windVector = new Vector3(1, 0, 0);
    public float boatSpeed = 15.0f;
    public float speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,(Input.GetAxis("Horizontal")*speed*Time.deltaTime),0f);
        Vector3 sailAngles = GameObject.Find("driversail").transform.right;
        float actualspeed = Mathf.Abs(boatSpeed * Mathf.Cos((Mathf.PI/180)*Vector3.Angle(windVector.normalized, sailAngles.normalized)));
        Debug.Log(Mathf.Cos((Mathf.PI/180)*Vector3.Angle(windVector.normalized, sailAngles.normalized)));
        //Debug.Log(actualspeed.ToString());
        if (actualspeed < 1.0)
        {
            speed = 1;
        }
        else
        {
            speed = actualspeed;
        }
        //Debug.Log(actualspeed.ToString());

    }
}
