using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public ScrbSummon tankStats;
    private int curentHealth;
    private float countdownToShoot;
    private bool tankFire = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        curentHealth = tankStats.maxHealth;
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        countdownToShoot += Time.deltaTime;
        if (countdownToShoot >= tankStats.shootingTime)
        {
            StartCoroutine(animationFire());

            Instantiate(tankStats.projectileTank, new Vector3(transform.position.x,transform.position.y, 0), transform.rotation);
            countdownToShoot = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D collWithSummon)
    {
        Debug.Log("I triggered");
        switch (collWithSummon.tag)
        {
            case "Summon":
                Debug.Log("I triggered 2");
                curentHealth -= collWithSummon.gameObject.GetComponent<SumomController>().damege;
                Destroy(collWithSummon.gameObject);
            break;
            case "SupperSummon":
                curentHealth -= collWithSummon.gameObject.GetComponent<SuperSummonController>().damege;
                Destroy(collWithSummon.gameObject);
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
}
