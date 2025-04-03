using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointsAndLevelController : MonoBehaviour
{
    public ScrbPoitsNLevels poitsNLevelsScrb;
    public UnityEvent upgradeWindowTrigger;
    private static ScrbPoitsNLevels poitsNLevelsStats;
    [NonSerialized]public static int points;
    private static int pointsToLeveling;
    [NonSerialized]public static int levels;
    private static int levelsToUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        poitsNLevelsStats = poitsNLevelsScrb;
        pointsToLeveling = poitsNLevelsStats.pointsToLevel;
        levelsToUpgrade = poitsNLevelsStats.levelsToUpgrade;
    }

    void Update()
    {
        if (points >= pointsToLeveling)
        {
            levels += 1;
            pointsToLeveling += poitsNLevelsStats.pointsToLevel;
        }
        if (levels >= levelsToUpgrade)
        {
            upgradeWindowTrigger.Invoke();
            levelsToUpgrade += poitsNLevelsStats.levelsToUpgrade;
        }
        Debug.Log(levels);
    }

    public static void AddPoints(string pointGuiver)
    {
        switch (pointGuiver)
        {
            case "tank":
                points += poitsNLevelsStats.tankKillPoints;
            break;
            case "turret":
                points += poitsNLevelsStats.turretKillPoints;
            break;
            case "earth":
                points += poitsNLevelsStats.earthHitPoints;
            break;
            default:
            break;
        }
    }
    void RemovePoints()
    {
        points -= poitsNLevelsStats.pointsToRemove;
    }

}
