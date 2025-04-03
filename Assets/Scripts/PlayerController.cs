using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public UnityEvent onDeath;

    public GameObject summon;
    public GameObject superSummon;
    private float summonColldown;
    public static int curantHealth;
    public static float countDownToSummon;
    public ScrbPlayer playerStats;
    private float coyoteTime;
    private float movementBufferRight;
    private float movementBufferLeft;
    public static float curentMana;
    [NonSerialized]public static float shieldCooldown;
    private float shieldUptime;
    private bool canSummon;
    public GameObject shield;
    private bool isPaused;
    public static bool canMove;
    private bool takeDamage;
    private bool activeShield;

    [Header("Paineis e Menus")]
    public GameObject chargeBar;
    public GameObject pausePanel;
    public GameObject uiPanel;
    public string cena;

    [Header("Anima��o")]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        canSummon = true;
        canMove = true;
        Time.timeScale = 1;
        curantHealth = playerStats.maxHealth;
        curentMana = 0f;
        countDownToSummon = 0;
        coyoteTime = -1f;
        movementBufferLeft = -1;
        movementBufferRight = -1;
        this.gameObject.transform.position = new Vector3(1.1f, 14.3f, 0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        takeDamage = false;
        activeShield = false;
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerStats.healthMax);
        //If game paused action in game don't run
        if(!isPaused)
        {
            //Player keyboard imputs
            switch (Input.GetKeyDown(KeyCode.D) && canMove == true)
            {
                //If player presses the key it sets the buffer to time
                case true:
                    movementBufferRight = playerStats.movementBuffer;
                    break;
                //After the press the buffer will slowly decrese
                default:
                    movementBufferRight -= Time.deltaTime;
                    break;
            }
            switch (Input.GetKeyDown(KeyCode.A) && canMove == true)
            {
                case true:
                    movementBufferLeft = playerStats.movementBuffer;
                    break;
                default:
                    movementBufferLeft -= Time.deltaTime;
                    break;
            }

            //Movement requests. Player can only move if buffer is >= then 0, same goes for coyote time
            if (movementBufferRight >= 0 && coyoteTime >= 0)
            {
                //Sets the buffer to 0 to avoid errors
                MoveToRight();
                movementBufferRight = 0;
            }
            else if (movementBufferLeft >= 0 && coyoteTime >= 0)
            {
                MoveToLeft();
                movementBufferLeft = 0;
            }

            //Shield and summoning handller
            if (Input.GetKey(KeyCode.Space))
            {
                chargeBar.SetActive(true);
                //Summon cooldown (I wrote Colldown, sry :|)
                if (summonColldown <= 0)
                {
                    Summon();
                }
                //Coyete time subtraction
                coyoteTime -= Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (curentMana >= playerStats.manaPerShield)
                {
                    ActivateShield();
                }
                //Coyete time subtraction
                coyoteTime -= Time.deltaTime;
            }
            if (Input.anyKey == false)
            {
                //If no key press, coyote time won't go down
                coyoteTime = playerStats.coyoteTime;
            }

            //Shield and summoning input Up handller
            if (Input.GetKeyUp(KeyCode.Space))
            {
                chargeBar.SetActive(false);
                //Sets coyote time to 0 to prevent any errors or bugs
                coyoteTime = 0f;
                //Resets the summoning delay time
                Summon();
                countDownToSummon = 0;
            }

            //Checs if player is dead and executes death if true
            if (curantHealth <= 0)
            {
                Death();
            }
            //Checs if the mana is surpassing the maximum mana
            if (curentMana > playerStats.maxMana)
            {
                curentMana = playerStats.maxMana;
            }

            //Resets summon the cooldown to 0
            if (summonColldown > 0)
            {
                summonColldown -= Time.deltaTime;
            }
            //Resets shield cooldown to 0
            if (shieldCooldown > 0)
            {
                shieldCooldown -= Time.deltaTime;
            }

            //Resets shield uptime to 0
            if (shieldUptime > 0)
            {
                shieldUptime -= Time.deltaTime;
            }
            if (shieldUptime <= 0 && shield.activeSelf == true)
            {
                shield.SetActive(false);
                shieldCooldown = playerStats.shieldCooldown;
            }
        }

        //Pauser jogo
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }
    }

    //Death
    void Death()
    {
        Time.timeScale = 0;
        canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        onDeath.Invoke();
    }

    //Summoning process
    void Summon()
    {
        countDownToSummon += Time.deltaTime;
        //After the delay
        if (countDownToSummon >= playerStats.holdToSuperSummonTime && canSummon == true)
        {
            //if there is mana
            if (curentMana >= playerStats.manaPerSuperSummon)
            {
                //Resets the delay
                countDownToSummon = 0;
                //Instantiates the super summon
                Instantiate(superSummon, new Vector3(transform.position.x,transform.position.y - 3, 0), Quaternion.identity);
                //Starts the summon cooldown
                summonColldown = playerStats.coolDownSummoning;
                curentMana -= playerStats.manaPerSuperSummon;
            }
            else
            {

            }
        }
        else if(countDownToSummon >= playerStats.holdToSummonTime && countDownToSummon < playerStats.holdToSuperSummonTime && coyoteTime == 0 && canSummon == true)
        {
            //if there is mana
            if (curentMana >= playerStats.manaPerSummon)
            {
                //Resets the delay
                countDownToSummon = 0;
                //Instantiates the super summon
                Instantiate(summon, new Vector3(transform.position.x,transform.position.y - 3, 0), Quaternion.identity);
                //Starts the summon cooldown
                summonColldown = playerStats.coolDownSummoning;
                curentMana -= playerStats.manaPerSummon;
            }
            else
            {

            }
        }
        else
        {

        }
    }

    //Movements
    void MoveToRight()
    {
        //On movement, a ray is cast to the side that the player wants to move
        //This way, it makes it eazy to create lanes and tp the player to them
        RaycastHit2D rightLane = Physics2D.Raycast(new Vector2(transform.position.x + 7, transform.position.y), transform.TransformDirection(Vector2.right), playerStats.laneMaxDistance);
        //This if is to prevent errors of no hit
        if (rightLane.collider == null)
        {
            Debug.Log("No collider " + rightLane.transform);
        }
        else if (rightLane.collider.gameObject.tag == "Lane")
        {
            //With hit the lane collider, it tps self to it
            transform.position = new Vector3(rightLane.collider.gameObject.transform.position.x, transform.position.y, 0);
        }
        else
        {

        }
        //It's the exect same thing for the left, only diference is that the ray is cast to the left
    }
    void MoveToLeft()
    {
        RaycastHit2D leftLane = Physics2D.Raycast(new Vector2(transform.position.x - 7, transform.position.y), transform.TransformDirection(Vector2.left), playerStats.laneMaxDistance);
        if (leftLane.collider == null)
        {
            Debug.Log("No collider" + leftLane.transform);
        }
        else if (leftLane.collider.gameObject.tag == "Lane")
        {
            transform.position = new Vector3(leftLane.collider.gameObject.transform.position.x, transform.position.y, 0);
        }
        else
        {

        }
    }

    //Shield
    void ActivateShield()
    {
        if (shieldCooldown <= 0 && shieldUptime <= 0)
        {
            shield.SetActive(true);

            StartCoroutine(animationShield());

            shieldUptime = playerStats.shieldUptime;
            curentMana -= playerStats.manaPerShield;
        }
    }

    //Collisions
    void OnTriggerEnter2D(Collider2D objColls)
    {
        switch (objColls.gameObject.tag)
        {
            case "ManaBall":
                if (curentMana <= playerStats.maxMana)
                {
                    curentMana += playerStats.manaPerManaBall;
                }
                else
                {

                }
            break;
            case "Projectile":
                if (shield.activeSelf != true)
                {
                    curantHealth -= objColls.gameObject.GetComponent<ProjectileColntroller>().damege;
                    StartCoroutine(animationDamage());
                }
            break;
            default:
            break;
        }
    }

    //Pause
    public void PauseScreen()
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            uiPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            uiPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    //Back to Menu
    public void BackToMenu()
    {
        SceneManager.LoadScene(cena);
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

    //Active Shield in Cleber
    IEnumerator animationShield()
    {
        Debug.Log("Entrou no escudo");

        activeShield = true;
        animator.SetBool("DefesaAtiva", activeShield);
        yield return new WaitForSeconds(playerStats.shieldUptime - 0.2f);
        activeShield = false;
        animator.SetBool("DefesaAtiva", activeShield);
    }
}
