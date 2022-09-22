using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public float xRotate = 5.0f;
    private float yRotate = 5.0f;

    private Vector3 cameraDistance;

    private bool shouldRotate;
    
    // Start is called before the first frame update
    void Start()
    {
        shouldRotate = false;
        cameraDistance = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetMouseButtonDown(0))
        {
            shouldRotate = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            shouldRotate = false;
        }

        if (shouldRotate)
        {
            Quaternion cameraAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * xRotate, Vector3.up);

            cameraDistance = cameraAngle * cameraDistance;
        }

        Vector3 newPosition = player.position + cameraDistance;

        transform.position = Vector3.Slerp(transform.position, newPosition, 0.5f);

        transform.LookAt(player.transform);
        
    }
}
