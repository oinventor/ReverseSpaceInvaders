using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public ScrbSummon tankStats;
    private int curentHealth;
    private string enemyType;
    private float countdownToShoot;
    private bool tankFire;
    private bool death;
    private char stateChar;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (tankStats.spawning != null)
        {
            AudioController.audioController.PlayAudioClip(tankStats.spawning, transform, 1f);
        }
        curentHealth = (int)tankStats.maxHealth;
        tankFire = false;
        death = false;
        animator = this.gameObject.GetComponent<Animator>();
        if (tankStats.tank == true)
        {
            enemyType = "tank";
        }
        else if (tankStats.turret == true)
        {
            enemyType = "turret";
        }
        int randomCounter = UnityEngine.Random.Range(1, (int)tankStats.enemyStateChance + 1);
        if (randomCounter < 1)
        {
            randomCounter = 1;
        }
        switch (randomCounter)
        {
            case 1:
                randomCounter = 0;
                randomCounter = UnityEngine.Random.Range(1, 3 + 1);
                switch (randomCounter)
                {
                    case 1:
                        stateChar = 'R';
                        this.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
                        if (this.transform.parent != null)
                        {
                            this.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
                        }
                        break;
                    case 2:
                        stateChar = 'G';
                        this.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                        if (this.transform.parent != null)
                        {
                            this.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                        }
                        break;
                    case 3:
                        stateChar = 'B';
                        this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
                        if (this.transform.parent != null)
                        {
                            this.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
                        }
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tankStats.updateBool == true)
        {
            tankStats.updateBool = false;
        }
        if (curentHealth <= 0)
        {
            StartCoroutine(animationDeath());
        }

        countdownToShoot += Time.deltaTime;
        if (countdownToShoot >= tankStats.shootingTime)
        {
            StartCoroutine(animationFire());

            Instantiate(tankStats.projectile, new Vector3(transform.position.x,transform.position.y, 0), transform.rotation);
            countdownToShoot = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D collWithSummon)
    {
        switch (collWithSummon.tag)
        {
            case "Summon":
                curentHealth -= (int)collWithSummon.gameObject.GetComponent<SumomController>().damege;
            if (tankStats.takingDamege != null)
            {
                AudioController.audioController.PlayAudioClip(tankStats.takingDamege, transform, 1f);
            }
            break;
            case "SupperSummon":
                curentHealth -= (int)collWithSummon.gameObject.GetComponent<SuperSummonController>().damege;
                if (tankStats.takingDamege != null)
                {
                    AudioController.audioController.PlayAudioClip(tankStats.takingDamege, transform, 1f);
                }
            break;
            case "MidSummon":
                curentHealth -= (int)collWithSummon.gameObject.GetComponent<MidSummonController>().damege;
                if (tankStats.takingDamege != null)
                {
                    AudioController.audioController.PlayAudioClip(tankStats.takingDamege, transform, 1f);
                }
            break;
            case "Explosion":
                curentHealth -= (int)collWithSummon.gameObject.GetComponent<ExplosionCOntroller>().damege;
                if (tankStats.takingDamege != null)
                {
                    AudioController.audioController.PlayAudioClip(tankStats.takingDamege, transform, 1f);
                }
            break;
            default:
            break;
        }
    }

    IEnumerator animationFire()
    {
        tankFire = true;
        animator.SetBool("Atirando", tankFire);
        if (tankStats.shooting != null)
        {
            AudioController.audioController.PlayAudioClip(tankStats.shooting, transform, 1f);
        }
        yield return new WaitForSeconds(1.0f);

        tankFire = false;
        animator.SetBool("Atirando", tankFire);
    }

    //Take damage in Cleber
    IEnumerator animationDeath()
    {
        if (death == false)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            switch (stateChar)
            {
                case 'R':
                    Instantiate(tankStats.explosionType, this.transform.position, Quaternion.identity);
                    break;
                case 'G':
                    break;
                case 'B':
                    break;
                default:
                    break;
            }
            if (tankStats.dying != null)
            {
                AudioController.audioController.PlayAudioClip(tankStats.dying, transform, 1f);
            }
            death = true;
        }
        death = true;
        animator.SetBool("Morte", death);
        if (tankStats.turret == true && tankStats.tank == false)
        {
            this.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
        }
        yield return new WaitForSeconds(tankStats.explosionType.GetComponent<ExplosionCOntroller>().animationCip.length);
        death = false;
        animator.SetBool("Morte", death);
        PointsAndLevelController.AddPoints(enemyType);
        Destroy(this.gameObject);
        if (tankStats.turret == true && tankStats.tank == false)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}
