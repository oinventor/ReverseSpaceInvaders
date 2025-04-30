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
    private bool takeDamage;
    private bool death;

    [Header("Anima��o")]
    public Animator animator;

    void Start()
    {
        damege = summonStats.damegeDelt;
        curantHealth = summonStats.maxHealth;
        dgmOnCountry = summonStats.dmgOnCountry;
        death = false;
        takeDamage = false;
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (summonStats.updateBool == true)
        {
            damege = summonStats.damegeDelt;
            curantHealth += summonStats.maxHealth - summonStats.healthMax;
            summonStats.updateBool = false;
        }
        if (curantHealth <= 0)
        {
            Debug.Log("Entrou na morte");

            StartCoroutine(animationDeath());
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
            EarthController.TakeDamege();
            Destroy(this.gameObject);
            break;
            default:
            break;
        }
    }
    public void TakeDamege(int damege)
    {
        curantHealth -= damege;
        StartCoroutine(animationDamage());
    }

    //Take damage in Cleber
    IEnumerator animationDamage()
    {
        takeDamage = true;
        animator.SetBool("DanoSofrido", takeDamage);
        yield return new WaitForSeconds(0.3f);
        takeDamage = false;
        animator.SetBool("DanoSofrido", takeDamage);
    }

    //Take damage in Cleber
    IEnumerator animationDeath()
    {
        Debug.Log("Morreu anima��o");

        death = true;
        animator.SetBool("Morte", death);
        yield return new WaitForSeconds(1.0f);
        death = false;
        animator.SetBool("Morte", death);
        Destroy(this.gameObject);
    }
}
