using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float TimeBetweenSpawns;
    public AnimationCurve SpawnEvolution;
    public BoxCollider2D[] zones;
    public GameObject EnnemyPrefab;
    public Transform EnnemyGroup;
    private float LastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > LastSpawn + TimeBetweenSpawns)
        {
            //on random le Vector2
            int zone = Random.Range(0, 4);
            Vector2 pos = new Vector2( 
                Random.Range(zones[zone].bounds.min.x, zones[zone].bounds.max.x),
                Random.Range(zones[zone].bounds.min.y, zones[zone].bounds.max.y));
            Instantiate(EnnemyPrefab, pos, Quaternion.identity,EnnemyGroup);
            LastSpawn = Time.time;
        }
    }
}
