using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneSpawner : MonoBehaviour
{
    public GameObject game_area;
    public GameObject wind_zone_prefab;
 
    public int wind_zone_count = 0;
    public int wind_zone_limit = 150;
    public int wind_zone_per_frame = 1;
 
    public float spawn_circle_radius = 80.0f;
    public float death_circle_radius = 90.0f;
 
    public float fastest_speed = 12.0f;
    public float slowest_speed = 0.75f;
 
    void Start()
    {
        InitialPopulation();
    }
 
    void Update()
    {
        MaintainPopulation();
    }
 
    void InitialPopulation()
    {
        /* To avoid having to wait for the wind zones to enter the screen at start up, create an
        initial set of wind zones for instant action. */
 
        for(int i=0; i<wind_zone_limit; i++)
        {
            Vector3 position = GetRandomPosition(true);
            WindZone wind_script = AddWindZone(position);
            // wind_script.transform.Rotate(Vector3.forward * Random.Range(0.0f, 360.0f));
            wind_script.transform.Rotate(Vector3.forward * Random.Range(0.0f, 360.0f));
        }
    }
 
    void MaintainPopulation()
    {
        /* Create more wind zones as old ones are destroyed, while respecting the object limit. */
 
        if(wind_zone_count < wind_zone_limit)
        {
            for(int i=0; i<wind_zone_per_frame; i++)
            {
                Vector3 position = GetRandomPosition(false);
                WindZone wind_script = AddWindZone(position);
                // wind_script.transform.Rotate(Vector3.forward * Random.Range(-45.0f,45.0f));
                wind_script.transform.Rotate(Vector3.forward * Random.Range(-45.0f,45.0f));
            }
        }
    }
 
    Vector3 GetRandomPosition(bool within_camera)
    {
        /* Get a random spawn position, using a 2D circle around the game area. */
 
        Vector3 position = Random.insideUnitCircle;

        position = new Vector3(position.x, 0, position.y); // Lay circle down flat on ground
 
        if(within_camera == false)
        {
            position = position.normalized;
        }
 
        position *= spawn_circle_radius;
        position += game_area.transform.position;

        return position;
    }
 
    WindZone AddWindZone(Vector3 position)
    {
        /* Add a new wind zone to the game and set the basic attributes. */
 
        wind_zone_count += 1;
        GameObject new_wind = Instantiate(
            wind_zone_prefab,
            position,
            Quaternion.FromToRotation(Vector3.up, (game_area.transform.position-position)),
            gameObject.transform
        );
 
        WindZone wind_script = new_wind.GetComponent<WindZone>();
        wind_script.wind_spawner = this;
        wind_script.game_area = game_area;
        wind_script.speed = Random.Range(slowest_speed, fastest_speed);
 
        return wind_script;
    }
}
