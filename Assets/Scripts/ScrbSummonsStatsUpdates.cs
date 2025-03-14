using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Summon Upgrade", menuName = "Scrbs/Stats Updates/Summon Upgrade")]
public class ScrbSummonsStatsUpdates : Upgrade
{
    [Header("Summon Stats ScriptableObject")]
    public ScrbSummon summonStats;

    [Header("///Aviso: este tipo de scriptable object contem informações sobre: ")]
    [Header("summons do player, inimigos e projeteis///")]

    [Header("Summon Related Stats Update")]
    public int healthMaxUpdate;
    public int damegeDeltOnCollisionUpdate;
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

    public override void UpdateStats()
    {
        summonStats.UpdateStats(healthMaxUpdate, damegeDeltOnCollisionUpdate, damegeDeltOnPlanetUpdate, followSpeedUpdate,
        movementCooldownUpdate, horizontalMovementUpdate, verticalMovementUpdate, rightMovementMaxDistanceUpdate,
        leftMovementMaxDistanceUpdate, shootingCooldownUpdate);
    }
}
