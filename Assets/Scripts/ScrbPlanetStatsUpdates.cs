using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Planet Entropy Wave", menuName = "Scrbs/Stats Updates/Planet Entropy Wave")]
public class ScrbPlanetStatsUpdates : ScriptableObject
{
    [Header("Updade Description")]
    [TextArea(3, 10)]
    public string description;

    [Header("Planet Stats ScriptableObject")]
    public ScrbCountry planetStats;
    [Header("Stats basicos Update")]
    public float firstSpawnTimeUpdate;
    public float timeForSapwnUpdate;
    public int healthMaxUpdate;
    public int healthConsumedPerEnemySpawnUpdate;

    public void UpdatePlanetStats()
    {
        planetStats.UpdateStats(firstSpawnTimeUpdate, timeForSapwnUpdate, healthMaxUpdate, healthConsumedPerEnemySpawnUpdate);
    }
}
