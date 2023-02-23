using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float TimeBetweenSpawns;

    public AnimationCurve   SpawnEvolution;

    //en secondes
    public float GameDuration;  


    public BoxCollider2D[] zones;
    public GameObject EnnemyPrefab;
    public Transform EnnemyGroup;
    private float LastSpawn;

    // Update is called once per frame
    void Update()
    {
        //Calculer où on en est sur la durée de la partie
        //calculer la valeur d'un pourcent, multiplier par le temps actuel
        float x = (GameDuration*Time.timeSinceLevelLoad) / 100 ;
        TimeBetweenSpawns = SpawnEvolution.Evaluate(x/100f);

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
