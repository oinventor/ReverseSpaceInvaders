using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointsAndLevelController : MonoBehaviour
{
    public UnityEvent upgradeWindowTrigger;
    [NonSerialized]public static int points;
    private static int pointsToLeveling;
    [NonSerialized]public static int levels;
    private static int levelsToUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        pointsToLeveling = 100;
        levelsToUpgrade = 5;
    }

    void Update()
    {
        if (points >= pointsToLeveling)
        {
            levels += 1;
            pointsToLeveling += 100;
        }
        if (levels >= levelsToUpgrade)
        {
            upgradeWindowTrigger.Invoke();
            levelsToUpgrade += 5;
        }
        Debug.Log(levels);
    }

    public static void AddPoints(string pointGuiver)
    {
        switch (pointGuiver)
        {
            case "tank":
                points += 100;
            break;
            case "turret":
                points += 200;
            break;
            case "earth":
                points += 300;
            break;
            default:
            break;
        }
    }
    void RemovePoints()
    {
        points -= 100;
    }

}
