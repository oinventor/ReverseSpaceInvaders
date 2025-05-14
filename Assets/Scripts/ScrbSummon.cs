using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Summon", menuName = "Scrbs/Summons")]
public class ScrbSummon : ScriptableObject
{
    [Header("///Aviso: este tipo de scriptable object contem informações sobre: ")]
    [Header("summons do player, inimigos e projeteis///")]

    [Header("If enemy, type:")]
    public bool projectileBool;
    public bool turret;
    public bool tank;

    [Header("Summon Related Stats")]
    public int healthMax;
    public int damegeDeltOnCollision;
    public int damegeDeltOnPlanet;

    [Header("Movement Related Stats")]
    public float followSpeed;
    public float movementCooldown;
    public float horizontalMovement;
    public float verticalMovement;
    public float rightMovementMaxDistance;
    public float leftMovementMaxDistance;

    [Header("Shoting Related Stats")]
    public GameObject projectile;
    public float shootingCooldown;

    [NonSerialized]
    public float maxHealth;
    [NonSerialized]
    public float damegeDelt;
    [NonSerialized]
    public int dmgOnCountry;
    [NonSerialized]
    public float shootingTime;
    [NonSerialized]
    public float rotationSpeed;
    [NonSerialized]
    public float coolDownMovimento;
    [NonSerialized]
    public float moveinetoHorizontal;
    [NonSerialized]
    public float movimentoVertical;
    [NonSerialized]
    public float distanciaMaxDireita;
    [NonSerialized]
    public float distanciaMaxEsquerda;
    [NonSerialized]
    public bool updateBool;
    [NonSerialized]
    public bool state11;
    [NonSerialized]
    public bool state22;
    [NonSerialized]
    public bool state33;

    public void LoadStats()
    {
        maxHealth = (float)healthMax;
        damegeDelt = (float)damegeDeltOnCollision;
        dmgOnCountry = damegeDeltOnPlanet;
        rotationSpeed = followSpeed;
        coolDownMovimento = movementCooldown;
        moveinetoHorizontal = horizontalMovement;
        movimentoVertical = verticalMovement;
        distanciaMaxDireita = rightMovementMaxDistance;
        distanciaMaxEsquerda = leftMovementMaxDistance;
        shootingTime = shootingCooldown;
        state11 = false;
        state22 = false;
        state33 = false;
        updateBool = false;
        Debug.Log("Summon Stats Loaded");
    }
    public void UpdateStats(float healthMax, float damegeDeltOnCollision, int damegeDeltOnPlanet, float followSpeed,
    float movementCooldown, float horizontalMovement, float verticalMovement, float rightMovementMaxDistance,
    float leftMovementMaxDistance, float shootingCooldown, bool state1, bool state2, bool state3)
    {
        maxHealth += healthMax;
        damegeDelt += damegeDeltOnCollision;
        dmgOnCountry += damegeDeltOnPlanet;
        rotationSpeed += followSpeed;
        coolDownMovimento += movementCooldown;
        moveinetoHorizontal += horizontalMovement;
        movimentoVertical += verticalMovement;
        distanciaMaxDireita += rightMovementMaxDistance;
        distanciaMaxEsquerda += leftMovementMaxDistance;
        shootingTime += shootingCooldown;
        if (state1 == true || state2 == true || state3 == true)
        {
            if (state1 == true)
            {
                state11 = state1;
                state22 = false;
                state33 = false;
            }
            else if (state2 == true)
            {
                state11 = false;
                state22 = state2;
                state33 = false;
            }
            else if (state3 == true)
            {
                state11 = false;
                state22 = false;
                state33 = state3;
            }
        }
        updateBool = true;
        Debug.Log("Summon Stats Updated");
    }
}
