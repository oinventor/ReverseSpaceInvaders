using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scrbs/Player")]
public class ScrbPlayer : ScriptableObject
{
    public int maxHealth;
    public float coolDownSummoning;
    public float holdToSuperSummonTime;
    public float holdToSummonTime;
    public int manaPerSummon;
    public int manaPerSuperSummon;
    public int maxMana;
    public int manaPerManaBall;
    public float manaPerShield;
    public float shieldManaDrainTime;
    public float laneMaxDistance;
    public float coyoteTime;
    public float movementBuffer;
}
