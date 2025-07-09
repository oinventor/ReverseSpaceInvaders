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
        if (summonStats.spawning != null)
        {
            AudioController.audioController.PlayAudioClip(summonStats.spawning, transform, 1f);
        }
        damege = (int)summonStats.damegeDelt;
        curantHealth = (int)summonStats.maxHealth;
        dgmOnCountry = summonStats.dmgOnCountry;
        death = false;
        takeDamage = false;
        animator = this.gameObject.GetComponent<Animator>();
        if (summonStats.state11)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(255,  0, 0);
        }
        else if (summonStats.state22)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
        else if (summonStats.state33)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (summonStats.updateBool == true)
        {
            damege = (int)summonStats.damegeDelt;
            curantHealth += (int)summonStats.maxHealth - summonStats.healthMax;
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
                if (summonStats.moving != null)
                {
                    AudioController.audioController.PlayAudioClip(summonStats.moving, transform, 1f);
                }
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
            if (summonStats.state11)
            {
                Instantiate(summonStats.explosionType, collWithObj.transform.position, Quaternion.identity);
            }
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
        if (summonStats.takingDamege != null)
        {
            AudioController.audioController.PlayAudioClip(summonStats.takingDamege, transform, 1f);
        }
        yield return new WaitForSeconds(0.3f);
        takeDamage = false;
        animator.SetBool("DanoSofrido", takeDamage);
    }

    //Take damage in Cleber
    IEnumerator animationDeath()
    {
        //Debug.Log("Morreu anima��o");
        if (summonStats.dying != null && death == false)
        {
            death = true;
            AudioController.audioController.PlayAudioClip(summonStats.dying, transform, 1f);
        }
        death = true;
        animator.SetBool("Morte", death);
        yield return new WaitForSeconds(summonStats.explosionType.GetComponent<ExplosionCOntroller>().animationCip.length);
        death = false;
        animator.SetBool("Morte", death);
        Destroy(this.gameObject);
    }
}
