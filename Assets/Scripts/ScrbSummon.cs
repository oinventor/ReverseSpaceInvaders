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
        updateBool = false;
        Debug.Log("Summon Stats Loaded");
    }
    public void UpdateStats(float healthMax, float damegeDeltOnCollision, int damegeDeltOnPlanet, float followSpeed,
    float movementCooldown, float horizontalMovement, float verticalMovement, float rightMovementMaxDistance,
    float leftMovementMaxDistance, float shootingCooldown)
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
        updateBool = true;
        Debug.Log("Summon Stats Updated");
    }
}
