using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scrbs/Player")]
public class ScrbPlayer : ScriptableObject
{
    public float coolDownSummoning;
    public float holdToSummonTime;
    public float laneMaxDistance;
    public float coyoteTime;
    public float movementBuffer;
}
