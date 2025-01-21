using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SumomController : MonoBehaviour
{
    private float movimentCooldownTime;
    public int damege;
    private float direction;
    private int curantHealth;
    public ScrbSummon summonStats;
    // Start is called before the first frame update
    void Start()
    {
        curantHealth = summonStats.maxHealth;
        damege = summonStats.damegeDelt;
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
                HorizontalMovement();
            break;
            default:
            break;
        }
        //If it reaches the maximum distance it can travel to the left
        if (this.transform.position.x < -summonStats.distanciaMaxEsquerda && direction == -1)
        {
            //It moves down an change directions
            StartCoroutine(VerticalMovement());
            direction *=-1f;
        }
        //Same thing, but now for the right
        else if (this.transform.position.x > summonStats.distanciaMaxDireita && direction == 1)
        {
            StartCoroutine(VerticalMovement());
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
    }

    //Vertical Movement
    IEnumerator VerticalMovement()
    {
        //Resets colldown (makes it slightly lower)
        movimentCooldownTime -= summonStats.coolDownMovimento;
        //Then wait for the cooldown
        yield return new WaitForSeconds(summonStats.coolDownMovimento);
        //Then it moves
        this.transform.position += new Vector3(0,-1*summonStats.movimentoVertical,0);
    }
    void OnTriggerEnter2D(Collider2D collWithTank)
    {
        if (collWithTank.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
    public void TakeDamege(int damege)
    {
        curantHealth -= damege;
    }
}

