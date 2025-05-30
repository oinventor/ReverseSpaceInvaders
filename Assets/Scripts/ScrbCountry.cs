using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Planet", menuName = "Scrbs/Planet")]
public class ScrbCountry : ScriptableObject
{
    [Header("Eath Sounds")]
    public AudioClip takingDamege;
    [Header("Stats basicos")]
    public float firstSpawnTime;
    public float timeForSapwn;
    public int healthMax;
    public int healthConsumedPerEnemySpawn;
    [Header("Inimigos spawnavels")]
    public GameObject inimigo1;
    public GameObject inimigo2;
    public GameObject inimigo3;

    [NonSerialized]
    public float startSpawnTime;
    [NonSerialized]
    public float spawnTime;
    [NonSerialized]
    public int maxHealth;
    [NonSerialized]
    public int healthPerSummon;
    [NonSerialized]
    public bool updateBool;

    public void LoadStats()
    {
        startSpawnTime = firstSpawnTime;
        spawnTime = timeForSapwn;
        maxHealth = healthMax;
        healthPerSummon = healthConsumedPerEnemySpawn;
        updateBool = false;
        Debug.Log("Planet Stats Loaded");
    }
    public void UpdateStats(float firstSpawnTime, float timeForSapwn,  int healthMax, int healthConsumedPerEnemySpawn)
    {
        startSpawnTime += firstSpawnTime;
        spawnTime += timeForSapwn;
        maxHealth += healthMax;
        healthPerSummon += healthConsumedPerEnemySpawn;
        updateBool = true;
        Debug.Log("Planet Stats Updated");
    }

}
