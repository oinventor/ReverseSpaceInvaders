using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Points 'n Levels", menuName = "Scrbs/Points 'n Levels")]
public class ScrbPoitsNLevels : ScriptableObject
{
    public int pointsToLevel;
    public int levelsToUpgrade;
    public int turretKillPoints;
    public int tankKillPoints;
    public int earthHitPoints;
    public int pointsToRemove;
}
