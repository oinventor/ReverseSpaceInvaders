using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject summon;
    private float summonColldown;
    private float countDownToSummon;
    public ScrbPlayer playerStats;
    private float coyoteTime;
    private float movementBufferRight;
    private float movementBufferLeft;
    public static float curentMana;

    // Start is called before the first frame update
    void Start()
    {
        countDownToSummon = playerStats.holdToSummonTime;
        this.gameObject.transform.position = new Vector3(0, 10f, 0);
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

        //Summoning imputs
        switch (Input.GetKey(KeyCode.Space))
        {
            case true:
                //Summon cooldown (I wrote Colldown, sry :|)
                if(summonColldown <= 0)
                {
                    Summon();
                }
                else
                {

                }
                //Coyete time subtraction
                coyoteTime -= Time.deltaTime;
            break;
            default:
                //If no space press, coyote time won't go down
                coyoteTime = playerStats.coyoteTime;
            break;
        }
        switch (Input.GetKeyUp(KeyCode.Space))
        {
            case true:
                //Sets coyote time to 0 to prevent any errors or bugs
                coyoteTime = 0f;
                //Resets the summoning delay time
                countDownToSummon = playerStats.holdToSummonTime;
            break;
            default:
            break;
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
        switch (countDownToSummon > 0)
        {
            //Summoning delay
            case true:
                countDownToSummon -= Time.deltaTime;
            break;
            default:
            break;
        }
        //After the delay
        if (countDownToSummon < 0)
        {
            //if there is mana
            if (curentMana > 0)
            {
                //Resets the delay
                countDownToSummon = playerStats.holdToSummonTime;
                //Instantiates the summon
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
        RaycastHit2D rightLane = Physics2D.Raycast(new Vector2(transform.position.x + 3, transform.position.y), transform.TransformDirection(Vector2.right), playerStats.laneMaxDistance);
        //This if is to prevent errors of no hit
        if (rightLane.collider == null)
        {
            Debug.Log("No collider");
        }
        else if (rightLane.collider.gameObject.tag == "Lane")
        {
            //With hit the lane collider, it tps self to it
            transform.position = rightLane.collider.gameObject.transform.position;
        }
        else
        {

        }
        //It's the exect same thing for the left, only diference is that the ray is cast to the left
    }
    void MoveToLeft()
    {
        RaycastHit2D leftLane = Physics2D.Raycast(new Vector2(transform.position.x - 3, transform.position.y), transform.TransformDirection(Vector2.left), playerStats.laneMaxDistance);
        if (leftLane.collider == null)
        {
            Debug.Log("No collider");
        }
        else if (leftLane.collider.gameObject.tag == "Lane")
        {
            transform.position = leftLane.collider.gameObject.transform.position;
        }
        else
        {

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
