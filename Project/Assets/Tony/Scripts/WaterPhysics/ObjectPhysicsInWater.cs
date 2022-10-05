using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectPhysicsInWater : MonoBehaviour
{
    public Transform[] floaters;
    public float underWaterDrag = 3F;
    public float underwaterAngularDrag = 1F;
    public float airDrag = 0F;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 135f;

    private Rigidbody m_Rigidbody;
    private int floatersUnderWater;
    private bool underwater;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        floatersUnderWater = 0;

        for (int i = 0; i < floaters.Length; i++)
        {
            float diff = floaters[i].position.y - OceanManager.Instance.WaterHeightAtPosition(floaters[i].position);
            if (diff < 0)
            {
                m_Rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(diff), floaters[i].position, ForceMode.Force);
                floatersUnderWater += 1;

                if (!underwater)
                {
                    underwater = true;
                    SwitchState(true);
                }
            }
            
            if (underwater && floatersUnderWater == 0)
            {
                underwater = false;
                SwitchState(false);
            }
        }

    }

    void SwitchState(bool isUnderWater)
    {
        if (isUnderWater)
        {
            m_Rigidbody.drag = underWaterDrag;
            m_Rigidbody.angularDrag = underwaterAngularDrag;
        }
        else
        {
            m_Rigidbody.drag = airDrag;
            m_Rigidbody.angularDrag = airAngularDrag;
        }
    }
}
