using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float TimeBetweenSpawns;


    public AnimationCurve   SpawnEvolution;

    //en secondes, la dur�e maximum de la partie, � partir de laquelle on atteint le max d'ennemis g�n�r�s
    public float GameDuration;  


    public BoxCollider2D[] zones;
    public GameObject EnnemyPrefab;
    public Transform EnnemyGroup;
    private float LastSpawn;

    // Update is called once per frame
    void Update()
    {
        //Calculer o� on en est sur la dur�e de la partie
        //calculer la valeur d'un pourcent, multiplier par le temps actuel
        
        // x repr�sente un centi�me de la dur�e de la partie
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
