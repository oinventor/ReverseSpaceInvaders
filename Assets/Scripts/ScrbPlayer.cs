using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStats", menuName = "Scrbs/Player")]
public class ScrbPlayer : ScriptableObject
{
    [Header("Player Related Stats")]
    public int healthMax;
    public int manaMax;
    public int manaRegen;
    public int heathSteal;

    [Header("Summon Related Stats")]
    public float summoningCoolDown;
    public int manaUsedPerMiniSummon;
    public int manaUsedPerMidSummon;
    public int manaUsedPerSuperSummon;

    [Header("Shield Related Stats")]
    public float coolDownShield;
    public float uptimeShield;
    public float manaUsedPerShield;

    [Header("Input Related Stats")]
    public float inputCoyoteTime;
    public float inputMovementBuffer;
    public float pressedTimeToMiniSummon;
    public float pressedTimeToMidSummon;
    public float pressedTimeToSuperSummon;
    public float laneDistance;

    [NonSerialized]
    public int stealHealth;
    [NonSerialized]
    public int maxHealth;
    [NonSerialized]
    public float coolDownSummoning;
    [NonSerialized]
    public float shieldCooldown;
    [NonSerialized]
    public float shieldUptime;
    [NonSerialized]
    public float holdToSuperSummonTime;
    [NonSerialized]
    public float holdToMidSummonTime;
    [NonSerialized]
    public float holdToSummonTime;
    [NonSerialized]
    public int manaPerSummon;
    [NonSerialized]
    public int manaPerMidSummon;
    [NonSerialized]
    public int manaPerSuperSummon;
    [NonSerialized]
    public int maxMana;
    [NonSerialized]
    public int manaPerManaBall;
    [NonSerialized]
    public float manaPerShield;
    [NonSerialized]
    public float laneMaxDistance;
    [NonSerialized]
    public float coyoteTime;
    [NonSerialized]
    public float movementBuffer;
    [NonSerialized]
    public bool updateBool;

    public void LoadStats()
    {
        maxHealth = healthMax;
        maxMana = manaMax;
        manaPerManaBall = manaRegen;
        stealHealth = heathSteal;
        coolDownSummoning = summoningCoolDown;
        manaPerSummon = manaUsedPerMiniSummon;
        manaPerMidSummon = manaUsedPerMidSummon;
        manaPerSuperSummon = manaUsedPerSuperSummon;
        shieldCooldown = coolDownShield;
        shieldUptime = uptimeShield;
        manaPerShield = manaUsedPerShield;
        coyoteTime = inputCoyoteTime;
        movementBuffer = inputMovementBuffer;
        holdToSummonTime = pressedTimeToMiniSummon;
        holdToMidSummonTime = pressedTimeToMidSummon;
        holdToSuperSummonTime = pressedTimeToSuperSummon;
        laneMaxDistance = laneDistance;
        Debug.Log("Player Stats Loaded");
        updateBool = false;
    }
    public void UpdateStats(int healthMax, int manaMax, int manaRegen, int heathSteal, float summoningCoolDown,
    int manaUsedPerMiniSummon, int manaUsedPerMidSummon, int manaUsedPerSuperSummon, float coolDownShield, float uptimeShield,
    float manaUsedPerShield, float inputCoyoteTime, float inputMovementBuffer, float pressedTimeToMiniSummon,
    float pressedTimeToMidSummon, float pressedTimeToSuperSummon, float laneDistance)
    {
        maxHealth += healthMax;
        maxMana += manaMax;
        manaPerManaBall += manaRegen;
        stealHealth += heathSteal;
        coolDownSummoning += summoningCoolDown;
        manaPerSummon += manaUsedPerMiniSummon;
        manaPerMidSummon += manaUsedPerMidSummon;
        manaPerSuperSummon += manaUsedPerSuperSummon;
        shieldCooldown += coolDownShield;
        shieldUptime += uptimeShield;
        manaPerShield += manaUsedPerShield;
        coyoteTime += inputCoyoteTime;
        movementBuffer += inputMovementBuffer;
        holdToSummonTime += pressedTimeToMiniSummon;
        holdToMidSummonTime += pressedTimeToMidSummon;
        holdToSuperSummonTime += pressedTimeToSuperSummon;
        laneMaxDistance += laneDistance;
        Debug.Log("Player Stats Updated");
        updateBool = true;
    }
}
