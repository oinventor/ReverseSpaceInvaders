using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Summon", menuName = "Scrbs/Summons")]
public class ScrbSummon : ScriptableObject
{
    [Header("///Aviso: este tipo de scriptable object contem informações sobre: ")]
    [Header("summons do player, inimigos e projeteis///")]

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
    public int maxHealth;
    [NonSerialized]
    public int damegeDelt;
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

    public void LoadStats()
    {
        maxHealth = healthMax;
        damegeDelt = damegeDeltOnCollision;
        dmgOnCountry = damegeDeltOnPlanet;
        rotationSpeed = followSpeed;
        coolDownMovimento = movementCooldown;
        moveinetoHorizontal = horizontalMovement;
        movimentoVertical = verticalMovement;
        distanciaMaxDireita = rightMovementMaxDistance;
        distanciaMaxEsquerda = leftMovementMaxDistance;
        shootingTime = shootingCooldown;
        Debug.Log("Summon Stats Loaded");
    }
}
