using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidSummonController : MonoBehaviour
{
    private float movimentCooldownTime;
    public int damege;
    private static int dgmOnCountry;
    private float direction;
    private int curantHealth;
    public ScrbSummon summonStats;
    private bool takeDamage;
    private bool death;

    [Header("Anima��o")]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (summonStats.spawning != null)
        {
            AudioController.audioController.PlayAudioClip(summonStats.spawning, transform, 1f);
        }
        curantHealth = (int)summonStats.maxHealth;
        dgmOnCountry = summonStats.dmgOnCountry;
        damege = (int)summonStats.damegeDelt;
        death = false;
        takeDamage = false;
        animator = this.gameObject.GetComponent<Animator>();
        if (summonStats.state11)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }
        else if (summonStats.state22)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
        else if (summonStats.state33)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
        }

        //This here will change the direction that the summon will go depending on where it spawns
        switch (this.transform.position.x >0)
        {
            case true:
                direction = -1;//Disclamer: -1 is right
            break;
            default:
                direction = 1;//Disclamer: 1 is left
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (summonStats.updateBool == true)
        {
            damege = (int)summonStats.damegeDelt;
            summonStats.updateBool = false;
        }
        if (curantHealth <= 0)
        {
            StartCoroutine(animationDeath());
        }

        //Increases the cooldown time
        movimentCooldownTime += Time.deltaTime;
        //So then when the cooldown reaches the trashold set by the Scrb
        switch (movimentCooldownTime >= summonStats.coolDownMovimento)
        {
            //It will move to a certan horizontal direction
            case true:
                HorizontalMovement();
            break;
            default:
            break;
        }
        //If it reaches the maximum distance it can travel to the left
        if (this.transform.position.x < -summonStats.distanciaMaxEsquerda && direction == -1)
        {
            //It moves down an change directions
            direction *=-1f;
        }
        //Same thing, but now for the right
        else if (this.transform.position.x > summonStats.distanciaMaxDireita && direction == 1)
        {
            direction *=-1f;
        }
        else
        {

        }
    }

    //Horizontal movement
    void HorizontalMovement()
    {
        //Resets cooldown
        movimentCooldownTime = 0;
        //Then it moves
        this.transform.position += new Vector3(summonStats.moveinetoHorizontal*direction,0,0);
        if (summonStats.moving != null)
        {
            AudioController.audioController.PlayAudioClip(summonStats.moving, transform, 1f);
        }
        StartCoroutine(VerticalMovement());
    }

    //Vertical Movement
    IEnumerator VerticalMovement()
    {
        //Resets colldown (makes it slightly lower)
        movimentCooldownTime -= summonStats.coolDownMovimento;
        //Then wait for the cooldown
        yield return new WaitForSeconds(summonStats.coolDownMovimento);
        //Then it moves
        this.transform.position += new Vector3(0, -1 * summonStats.movimentoVertical, 0);
        if (summonStats.moving != null)
        {
            AudioController.audioController.PlayAudioClip(summonStats.moving, transform, 1f);
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
        animator.SetBool("Morte", death);
        if (summonStats.dying != null && death == false)
        {
            death = true;
            AudioController.audioController.PlayAudioClip(summonStats.dying, transform, 1f);
        }
        yield return new WaitForSeconds(1.0f);
        death = false;
        animator.SetBool("Morte", death);
        Destroy(this.gameObject);
    }
}
