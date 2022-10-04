using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSails : MonoBehaviour

{
    public Vector3 windVector = new Vector3(1, 0, 0);
    public Vector3 SailVector3 = GameObject.Find("sail direction").transform.right.normalized;
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
        float angle = Vector3.Angle(windVector, SailVector3);
        Debug.Log(angle.ToString());
        float actualspeed = boatSpeed * angle;
        
        if (actualspeed < 1.0)
        {
            actualspeed = 1;
        }
        Debug.Log(actualspeed.ToString());

    }
}
