using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSummonController : MonoBehaviour
{
    public int damege;
    private static int dgmOnCountry;
    private float movimentCooldownTime;
    private int curantHealth;
    public ScrbSummon summonStats;

    void Start()
    {
        damege = summonStats.damegeDelt;
        curantHealth = summonStats.maxHealth;
        dgmOnCountry = summonStats.dmgOnCountry;
    }

    // Update is called once per frame
    void Update()
    {
        if (curantHealth <= 0)
        {
            Destroy(this.gameObject);
        }
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
    void OnTriggerEnter2D(Collider2D collWithObj)
    {
        switch (collWithObj.tag)
        {
            case "Enemy":
            Destroy(this.gameObject);
            break;
            case "Country":
            EarthController.TakeDamege(dgmOnCountry);
            Destroy(this.gameObject);
            break;
            default:
            break;
        }
    }
    public void TakeDamege(int damege)
    {
        curantHealth -= damege;
    }
}
