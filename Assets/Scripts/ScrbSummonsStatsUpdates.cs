using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Summon Upgrade", menuName = "Scrbs/Stats Updates/Summon Upgrade")]
public class ScrbSummonsStatsUpdates : Upgrade
{
    [Header("DO NEVER TOUCH THIS IF YOU DON'T KNOW WHAT IT IS")]
    public bool dificultyIncreaseBool;


    [Header("Summon Stats ScriptableObject")]
    public ScrbSummon summonStats;

    [Header("///Aviso: este tipo de scriptable object contem informações sobre: ")]
    [Header("summons do player, inimigos e projeteis///")]

    [Header("Summon Related Stats Update")]
    public float healthMaxUpdate;
    public float damegeDeltOnCollisionUpdate;
    public int damegeDeltOnPlanetUpdate;

    [Header("Movement Related Stats Update")]
    public float followSpeedUpdate;
    public float movementCooldownUpdate;
    public float horizontalMovementUpdate;
    public float verticalMovementUpdate;
    public float rightMovementMaxDistanceUpdate;
    public float leftMovementMaxDistanceUpdate;

    [Header("Shoting Related Stats Update")]
    public float shootingCooldownUpdate;
    [Header("States Related Stats")]
    private float chanceForEnemyStateUpdate;
    public bool state1;
    public bool state2;
    public bool state3;

    public override void UpdateStats()
    {
        if (dificultyIncreaseBool == true)
        {
            healthMaxUpdate = 0;
            damegeDeltOnCollisionUpdate = 0;
            chanceForEnemyStateUpdate = 0;
            if (summonStats.turret == true || summonStats.tank == true || summonStats.projectileBool == true)
            {
                healthMaxUpdate = summonStats.healthMax * PointsAndLevelController.dificulty;
                damegeDeltOnCollisionUpdate = summonStats.damegeDeltOnCollision * PointsAndLevelController.dificulty;
                chanceForEnemyStateUpdate = summonStats.chanceForEnemyState * -PointsAndLevelController.dificulty;
            }
        }
        summonStats.UpdateStats(healthMaxUpdate, damegeDeltOnCollisionUpdate, damegeDeltOnPlanetUpdate, followSpeedUpdate,
        movementCooldownUpdate, horizontalMovementUpdate, verticalMovementUpdate, rightMovementMaxDistanceUpdate,
        leftMovementMaxDistanceUpdate, shootingCooldownUpdate, state1, state2, state3, chanceForEnemyStateUpdate);
    }
}
