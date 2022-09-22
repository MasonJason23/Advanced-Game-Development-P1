using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMover : MonoBehaviour
{
    private float speed;
    private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        rotateSpeed = 80f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += (transform.forward ) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotateSpeed);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotateSpeed);
        }
    }
}
