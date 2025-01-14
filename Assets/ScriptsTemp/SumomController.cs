using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SumomController : MonoBehaviour
{
    private float movimentColldownTime;
    private float direction;
    public ScrbSummon summonStats;
    // Start is called before the first frame update
    void Start()
    {

        switch (this.transform.position.x >0)
        {
            case true:
                direction = -1;
            break;
            default:
                direction = 1;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movimentColldownTime += Time.deltaTime;
        switch (movimentColldownTime >= summonStats.coolDownMovimento)
        {
            case true:
                HorizontalMovement();
            break;
            default:
            break;
        }
        if (this.transform.position.x < -summonStats.distanciaMaxEsquerda && direction == -1)
        {
            StartCoroutine(VerticalMovement());
            direction *=-1f;
        }
        else if (this.transform.position.x > summonStats.distanciaMaxDireita && direction == 1)
        {
            StartCoroutine(VerticalMovement());
            direction *=-1f;
        }
        else
        {

        }
    }
    void HorizontalMovement()
    {
        movimentColldownTime = 0;
        this.transform.position += new Vector3(summonStats.moveinetoHorizontal*direction,0,0);
    }
    IEnumerator VerticalMovement()
    {
        movimentColldownTime -= summonStats.coolDownMovimento;
        yield return new WaitForSeconds(summonStats.coolDownMovimento);
        this.transform.position += new Vector3(0,-1*summonStats.movimentoVertical,0);
    }
}

