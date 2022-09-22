using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSails : MonoBehaviour

{
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
        Vector3 sailAngles = GameObject.Find("driversail").transform.position.normalized;
        float actualspeed = boatSpeed * Mathf.Cos(GameObject.Find("driversail").transform.rotation.normalized.y*2.5f);
        Debug.Log(actualspeed.ToString());
        if (actualspeed < 1.0)
        {
            actualspeed = 1;
        }

    }
}
