using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject summon;
    public GameObject superSummon;
    private float summonColldown;
    private float countDownToSummon;
    public ScrbPlayer playerStats;
    private float coyoteTime;
    private float movementBufferRight;
    private float movementBufferLeft;
    public static float curentMana;
    private float curantShiledActiveTime;
    private bool canSummon;
    public GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        countDownToSummon = 0;
        this.gameObject.transform.position = new Vector3(0, 5.2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Player imputs
        switch (Input.GetKeyDown(KeyCode.D))
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
        //Same here
        switch (Input.GetKeyDown(KeyCode.A))
        {
            case true:
                movementBufferLeft = playerStats.movementBuffer;
            break;
            default:
                movementBufferLeft -= Time.deltaTime;
            break;
        }

        //Movement inputs. Player can only move if buffer is >= then 0, same goes for coyote time
        if (movementBufferRight >= 0 && coyoteTime >= 0)
        {
            //Sets the buffer to 0 to avoid errors
            MoveToRight();
            movementBufferRight = 0;
        }
        else if(movementBufferLeft >= 0 && coyoteTime >= 0)
        {
            MoveToLeft();
            movementBufferLeft = 0;
        }
        else
        {

        }

        //Input handller
        if (Input.GetKey(KeyCode.Space))
        {
            //Summon cooldown (I wrote Colldown, sry :|)
            if(summonColldown <= 0)
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
                curentMana -= playerStats.manaPerShield;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            ActivateShield();
            coyoteTime -= Time.deltaTime;

        }
        if (Input.anyKey == false)
        {
            Debug.Log("curantShiledActiveTime");
            //If no key press, coyote time won't go down
            coyoteTime = playerStats.coyoteTime;
        }

        //Input Up handller
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //Sets coyote time to 0 to prevent any errors or bugs
            coyoteTime = 0f;
            //Resets the summoning delay time
            Summon();
            countDownToSummon = 0;
        }
        else if (Input.GetKeyUp(KeyCode.S) && shield.activeSelf == true || curentMana < playerStats.manaPerShield)
        {
            shield.SetActive(false);
            canSummon = true;
            curantShiledActiveTime = 0;
        }

        //Checs if the mana is surpassing the maximum mana
        if (curentMana > playerStats.maxMana)
        {
            curentMana = playerStats.maxMana;
        }
        else
        {

        }

        //Resets the cooldown to 0
        if (summonColldown > 0)
        {
            summonColldown -= Time.deltaTime;
        }
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
        RaycastHit2D rightLane = Physics2D.Raycast(new Vector2(transform.position.x + 7, transform.position.y + 4.8f), transform.TransformDirection(Vector2.right), playerStats.laneMaxDistance);
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
        RaycastHit2D leftLane = Physics2D.Raycast(new Vector2(transform.position.x - 7, transform.position.y + 4.8f), transform.TransformDirection(Vector2.left), playerStats.laneMaxDistance);
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
        if (curentMana >= playerStats.manaPerShield)
        {
            shield.SetActive(true);
            if (shield.activeSelf == true)
            {
                canSummon = false;
                curantShiledActiveTime += Time.deltaTime;
            }
            if (curantShiledActiveTime >= playerStats.shieldManaDrainTime)
            {
                curentMana -= playerStats.manaPerShield;
                curantShiledActiveTime = 0;
            }
        }
    }
    //Adds mana when colecting mana balls
    void OnTriggerEnter2D(Collider2D manaColl)
    {
        switch (manaColl.gameObject.tag == "ManaBall")
        {
            case true:
                if (curentMana <= playerStats.maxMana)
                {
                    curentMana += playerStats.manaPerManaBall;
                }
                else
                {

                }
            break;
            default:
            break;
        }
    }
}
