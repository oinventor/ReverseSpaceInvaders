using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Planet Entropy Wave", menuName = "Scrbs/Stats Updates/Planet Entropy Wave")]
public class ScrbPlanetStatsUpdates : Upgrade
{
    [Header("DO NEVER TOUCH THIS IF YOU DON'T KNOW WHAT IT IS")]
    public bool dificultyIncreaseBool;


    [Header("Planet Stats ScriptableObject")]
    public ScrbCountry planetStats;
    [Header("Stats basicos Update")]
    public float firstSpawnTimeUpdate;
    public float timeForSapwnUpdate;
    public int healthMaxUpdate;
    public int healthConsumedPerEnemySpawnUpdate;

    public override void UpdateStats()
    {
        if (dificultyIncreaseBool == true)
        {
            timeForSapwnUpdate = 0;
            timeForSapwnUpdate = planetStats.timeForSapwn * PointsAndLevelController.dificulty * -1;
        }
        planetStats.UpdateStats(firstSpawnTimeUpdate, timeForSapwnUpdate, healthMaxUpdate, healthConsumedPerEnemySpawnUpdate);
    }
}
