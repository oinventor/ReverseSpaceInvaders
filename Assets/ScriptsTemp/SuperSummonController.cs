using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSummonController : MonoBehaviour
{
    public int damege;
    private float movimentCooldownTime;
    public ScrbSummon summonStats;

    void Start()
    {
        damege = summonStats.damegeDelt;

    }

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
                movimentCooldownTime = 0;
            break;
            default:
            break;
        }
    }
    void OnTriggerEnter2D(Collider2D collWithTank)
    {
        if (collWithTank.gameObject.tag == "Tank")
        {
            Destroy(this.gameObject);
        }
    }
}
