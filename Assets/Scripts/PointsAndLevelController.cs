using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointsAndLevelController : MonoBehaviour
{
    public GameObject spawnPlataform4;
    public GameObject spawnPlataform5;
    public GameObject spawnPlataform6;
    public GameObject spawnPlataform7;
    public GameObject lane4;
    public GameObject lane5;
    public GameObject lane6;
    public GameObject lane7;

    public ScrbPoitsNLevels poitsNLevelsScrb;
    public UnityEvent upgradeWindowTrigger;
    public UnityEvent dificultyIncreaseTrigger;
    private static ScrbPoitsNLevels poitsNLevelsStats;
    private int levelsToDificulty;
    [NonSerialized]public static float dificulty;
    [NonSerialized]public static int points;
    public static int pointsToLeveling;
    [NonSerialized]public static int levels;
    private static int levelsToUpgrade;
    [NonSerialized]public static int xp;
    // Start is called before the first frame update
    void Start()
    {
        levels = 0;
        points = 0;
        xp = 0;
        poitsNLevelsStats = poitsNLevelsScrb;
        pointsToLeveling = poitsNLevelsStats.pointsToLevel;
        levelsToUpgrade = poitsNLevelsStats.levelsToUpgrade;
        levelsToDificulty = poitsNLevelsStats.levelsToIncreaseDificulty;
    }

    void Update()
    {
        if (points >= pointsToLeveling)
        {
            levels += 1;
            pointsToLeveling += poitsNLevelsStats.pointsToLevel;
            xp -= poitsNLevelsStats.pointsToLevel;
        }
        if (levels >= levelsToUpgrade)
        {
            upgradeWindowTrigger.Invoke();
            levelsToUpgrade += poitsNLevelsStats.levelsToUpgrade;
        }
        if (levels >= levelsToDificulty)
        {
            levelsToDificulty += poitsNLevelsStats.levelsToIncreaseDificulty;
            dificulty += poitsNLevelsStats.dificultyIncrease;
            dificultyIncreaseTrigger.Invoke();
        }
    }

    public static void AddPoints(string pointGuiver)
    {
        switch (pointGuiver)
        {
            case "tank":
                points += poitsNLevelsStats.tankKillPoints;
                xp += poitsNLevelsStats.tankKillPoints;
            break;
            case "turret":
                points += poitsNLevelsStats.turretKillPoints;
                xp += poitsNLevelsStats.turretKillPoints;
            break;
            case "earth":
                points += poitsNLevelsStats.earthHitPoints;
                xp += poitsNLevelsStats.earthHitPoints;
            break;
            default:
            break;
        }
    }
    public void LaneUpdade()
    {
        if (levels >= poitsNLevelsScrb.levelsToLane1)
        {
            lane4.SetActive(true);
            spawnPlataform4.SetActive(true);
        }
        if (levels >= poitsNLevelsScrb.levelsToLane2)
        {
            lane5.SetActive(true);
            spawnPlataform5.SetActive(true);
        }
        if (levels >= poitsNLevelsScrb.levelsToLane3)
        {
            lane6.SetActive(true);
            spawnPlataform6.SetActive(true);
        }
        if (levels >= poitsNLevelsScrb.levelsToLane4)
        {
            lane7.SetActive(true);
            spawnPlataform7.SetActive(true);
        }
    }
    void RemovePoints()
    {
        points -= poitsNLevelsStats.pointsToRemove;
    }

}
