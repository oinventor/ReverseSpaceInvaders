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
    [NonSerialized]
    public bool updateBool;

    public void LoadStats()
    {
        tempoDeSpawn = spawnTime;
        randMax = xSpawnChance;
        updateBool = false;
        Debug.Log("Spawnable Stats Loaded");
    }
    public void UpdateStats(float spawnTime, int xSpawnChance)
    {
        tempoDeSpawn += spawnTime;
        randMax += xSpawnChance;
        updateBool = true;
        Debug.Log("Spawnable Stats Updated");
    }
}
