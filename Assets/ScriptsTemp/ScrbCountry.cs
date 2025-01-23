using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Country Stats", menuName = "Scrbs/Contry")]
public class ScrbCountry : ScriptableObject
{
    public float spawnTime;
    public int maxHealth;
    public int healthPerSummon;
    public GameObject spawnable1;
    public GameObject spawnable2;
    public GameObject spawnable3;

}
