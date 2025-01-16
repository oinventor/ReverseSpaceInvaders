using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSummonController : MonoBehaviour
{
    private float movimentCooldownTime;
    public ScrbSummon summonStats;

    // Update is called once per frame
    void Update()
    {
        //Increases the cooldown time
        movimentCooldownTime += Time.deltaTime;
        //So then when the cooldown reaches the trashold set by the Scrb
        switch (movimentCooldownTime >= summonStats.coolDownMovimento)
        {
            //It will move to a certan horizontal direction
            case true:
                this.transform.position += new Vector3(0, summonStats.movimentoVertical *-1,0);
            break;
            default:
            break;
        }
    }
}
