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
    private int levelsToDificulty;
    [NonSerialized]public static int dificulty;
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
        levelsToDificulty = poitsNLevelsStats.levelsToIncreaseDificulty;
        dificulty = 1;
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
        if (levels >= levelsToDificulty)
        {
            levelsToDificulty += poitsNLevelsStats.levelsToIncreaseDificulty;
            dificulty += 1;
        }
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
