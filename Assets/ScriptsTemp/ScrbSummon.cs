using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Summon", menuName = "Scrbs/Summons")]
public class ScrbSummon : ScriptableObject
{
    public float coolDownMovimento;
    public float moveinetoHorizontal;
    public float movimentoVertical;
    public float distanciaMaxDireita;
    public float distanciaMaxEsquerda;
}
