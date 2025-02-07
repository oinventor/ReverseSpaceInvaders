using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Spawn", menuName = "Scrbs/Spawns")]
public class ScrbSpawns : ScriptableObject
{
    public GameObject spawn;
    public float tempoDeSpawn;
    public int randMin;
    public int randMax;
}
