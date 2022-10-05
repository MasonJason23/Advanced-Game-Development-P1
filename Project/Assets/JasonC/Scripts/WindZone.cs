using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WindZone : MonoBehaviour
{
    public WindZoneSpawner wind_spawner;
    public GameObject game_area;
 
    public float speed;

    public float windSpeed;

    public bool boatPhase = false;

    private void Start()
    {
        FindObjectOfType<GameManager>().changePhase += UpdateCurrentState;
        
        var localScale = gameObject.transform.localScale;
        localScale *= Random.Range(1, 10);
        gameObject.transform.localScale = localScale;
        windSpeed = localScale.x * Random.Range(1f, 2f);

        Vector3 currPos = transform.position;
        transform.position = new Vector3(currPos.x, 1f, currPos.z);
    }

    void Update()
    {
        if (!boatPhase) return; 
        Move();
    }
 
    void Move()
    {
        /* Move this wind zone forward per frame, if it gets too far from the game area, destroy it */
 
        transform.position += transform.up * (Time.deltaTime * speed);
 
        float distance = Vector3.Distance(transform.position, game_area.transform.position);
        
        Vector3 currPos = transform.position;
        transform.position = new Vector3(currPos.x, 1f, currPos.z);
        if(distance > wind_spawner.death_circle_radius)
        {
            RemoveShip();
        }
    }
 
    void RemoveShip()
    {
        /* Update the total wind zone count and then destroy this individual wind zone. */
 
        Destroy(gameObject);
        wind_spawner.wind_zone_count -= 1;
    }

    void UpdateCurrentState(GamePhase state)
    {
        boatPhase = state == GamePhase.BOATPHASE;
    }

    void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(transform.up * windSpeed, ForceMode.Acceleration);
    }
}
