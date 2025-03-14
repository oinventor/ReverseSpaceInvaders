using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn Entropy Wave", menuName = "Scrbs/Stats Updates/Spawn Entropy Wave")]
public class ScrbSpawnsStatsUpdates : Upgrade
{
    [Header("Spawn Stats ScriptableObject")]
    public ScrbSpawns spawnsStats;

    [Header("Basic Stats Updates Update")]
    public float spawnTimeUpdate;

    [Header("///Sempre 1 em X chances///")]
    public int xSpawnChanceUpdate ;

    public override void UpdateStats()
    {
        spawnsStats.UpdateStats(spawnTimeUpdate, xSpawnChanceUpdate);
    }
}
