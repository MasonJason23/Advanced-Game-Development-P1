using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static OceanManager instance;
    public static OceanManager Instance {get => instance;}

    public GameObject ocean;
    public float waveFrequency = 0.6f;
    public float waveSpeed = 0.1f;
    public float waveHeight = 2f;
    Material oceanMat;
    Texture2D displacementWaves;
    void Start()
    {
        SetVariables();

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void SetVariables()
    {
        oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        displacementWaves = (Texture2D)oceanMat.GetTexture("_Displacement");
    }

    // Update is called once per frame
    public float WaterHeightAtPosition(Vector3 position)
    {
        return displacementWaves.GetPixelBilinear(position.x * waveFrequency, position.z * waveFrequency + Time.time * waveSpeed).g * waveHeight * ocean.transform.localScale.x;
    }

     private void OnValidate() 
    {
        if(!oceanMat)
        {
            SetVariables();
        }    

        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        oceanMat.SetFloat("_Displace_Strength", waveFrequency);
        oceanMat.SetFloat("_Pan_Speed", waveSpeed);
        oceanMat.SetFloat("_WaveHeight", waveHeight);
    
    }
}
