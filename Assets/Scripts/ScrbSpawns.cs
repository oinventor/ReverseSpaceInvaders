using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Spawn", menuName = "Scrbs/Spawns")]
public class ScrbSpawns : ScriptableObject
{
    [Header("Stats Basicos")]
    public float spawnTime;

    [Header("///Sempre 1 em X chances///")]
    public int xSpawnChance ;

    [Header("Objeto Spawnavel")]
    public GameObject spawn;

    [NonSerialized]
    public float tempoDeSpawn;
    [NonSerialized]
    public int randMax;

    public void LoadStats()
    {
        tempoDeSpawn = spawnTime;
        randMax = xSpawnChance;
        Debug.Log("Spawnable Stats Loaded");
    }
}
