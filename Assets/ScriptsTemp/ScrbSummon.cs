using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Summon", menuName = "Scrbs/Summons")]
public class ScrbSummon : ScriptableObject
{
    public GameObject projectileTank;
    public int maxHealth;
    public int damegeDelt;
    public int dmgOnCountry;
    public float shootingTime;
    public float rotationSpeed;
    public float coolDownMovimento;
    public float moveinetoHorizontal;
    public float movimentoVertical;
    public float distanciaMaxDireita;
    public float distanciaMaxEsquerda;
    public float shootSpeed;
}
