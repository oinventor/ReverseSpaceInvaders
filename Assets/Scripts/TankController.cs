using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public ScrbSummon tankStats;
    private int curentHealth;
    private string enemyType;
    private float countdownToShoot;
    private bool tankFire;
    private bool death;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
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
            break;
            case "SupperSummon":
                curentHealth -= (int)collWithSummon.gameObject.GetComponent<SuperSummonController>().damege;
            break;
            case "MidSummon":
                curentHealth -= (int)collWithSummon.gameObject.GetComponent<MidSummonController>().damege;
            break;
            case "Explosion":
                curentHealth -= (int)collWithSummon.gameObject.GetComponent<ExplosionCOntroller>().damege;
            break;
            default:
            break;
        }
    }

    IEnumerator animationFire()
    {
        tankFire = true;
        animator.SetBool("Atirando", tankFire);

        yield return new WaitForSeconds(1.0f);

        tankFire = false;
        animator.SetBool("Atirando", tankFire);
    }

    //Take damage in Cleber
    IEnumerator animationDeath()
    {
        death = true;
        animator.SetBool("Morte", death);
        if (tankStats.turret == true && tankStats.tank == false)
        {
            this.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
        }
        yield return new WaitForSeconds(1.0f);
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
