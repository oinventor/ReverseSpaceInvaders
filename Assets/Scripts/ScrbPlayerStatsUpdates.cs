using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Upgrade", menuName = "Scrbs/Stats Updates/Player Upgrade")]
public class ScrbPlayerStatsUpdates : Upgrade
{
    [Header("Player Stats ScriptableObject")]
    public ScrbPlayer playerStats;

    [Header("Player Related Stats Updates")]
    public int healthMaxUpdate;
    public int manaMaxUpdate;
    public int manaRegenUpdate;
    public int heathStealUpdate;

    [Header("Summon Related Stats Updates")]
    public float summoningCoolDownUpdate;
    public int manaUsedPerMiniSummonUpdate;
    public int manaUsedPerMidSummonUpdate;
    public int manaUsedPerSuperSummonUpdate;

    [Header("Shield Related Stats Updates")]
    public float coolDownShieldUpdate;
    public float uptimeShieldUpdate;
    public float manaUsedPerShieldUpdate;

    [Header("Input Related Stats Updates")]
    public float inputCoyoteTimeUpdate;
    public float inputMovementBufferUpdate;
    public float pressedTimeToMiniSummonUpdate;
    public float pressedTimeToMidSummonUpdate;
    public float pressedTimeToSuperSummonUpdate;
    public float laneDistanceUpdate;

    public override void UpdateStats()
    {
        playerStats.UpdateStats(healthMaxUpdate, manaMaxUpdate, manaRegenUpdate, heathStealUpdate, summoningCoolDownUpdate,
        manaUsedPerMiniSummonUpdate, manaUsedPerMidSummonUpdate, manaUsedPerSuperSummonUpdate, coolDownShieldUpdate, uptimeShieldUpdate,
        manaUsedPerShieldUpdate, inputCoyoteTimeUpdate, inputMovementBufferUpdate, pressedTimeToMiniSummonUpdate,
        pressedTimeToMidSummonUpdate, pressedTimeToSuperSummonUpdate, laneDistanceUpdate);
    }
}
