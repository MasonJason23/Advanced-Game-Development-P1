using UnityEngine;

public class boatsteering : MonoBehaviour
{
    private Rigidbody boat;

    private readonly float m_drag = 0.9997f;

    // Start is called before the first frame update
    private float m_rotation;
    private readonly float m_rotationIncrement = 0.1f;
    private readonly float m_rotationLimit = 45; // 45 degrees

    private void Start()
    {
        boat = GameObject.Find("playerShip").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        //GameObject driversial = GameObject.Find("driversail");
        //rotatesails rotateSailsobj = driversial.GetComponent<rotatesails>();
        var Setspeed = GameObject.Find("driversail").GetComponent<rotatesails>().speed;
        if (Input.GetKey("left")) m_rotation += -m_rotationIncrement * Time.deltaTime;

        if (Input.GetKey("right")) m_rotation += m_rotationIncrement * Time.deltaTime;

        m_rotation = Mathf.Clamp(m_rotation, -m_rotationLimit, m_rotationLimit);

        //boat.transform.Rotate(0, m_rotation, 0);
        m_rotation *= m_drag;
        boat.transform.Rotate(0, m_rotation, 0);
        Vector3 boatForward = boat.transform.forward.normalized * Setspeed;

        boat.velocity = boatForward;
    }
}