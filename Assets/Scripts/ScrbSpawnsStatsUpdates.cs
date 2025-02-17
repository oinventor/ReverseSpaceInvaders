using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn Entropy Wave", menuName = "Scrbs/Stats Updates/Spawn Entropy Wave")]
public class ScrbSpawnsStatsUpdates : ScriptableObject
{
    [Header("Updade Description")]
    [TextArea(3, 10)]
    public string description;

    [Header("Spawn Stats ScriptableObject")]
    public ScrbSpawns spawnsStats;

    [Header("Basic Stats Updates Update")]
    public float spawnTimeUpdate;

    [Header("///Sempre 1 em X chances///")]
    public int xSpawnChanceUpdate ;

    public void UpdateSpawnStats()
    {
        spawnsStats.UpdateStats(spawnTimeUpdate, xSpawnChanceUpdate);
    }
}
