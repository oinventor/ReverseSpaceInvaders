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

    // Start is called before the first frame update
    void Start()
    {
        countDownToSummon = playerStats.holdToSummonTime;
        this.gameObject.transform.position = new Vector3(0, 10f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Movement inputs
        if (Input.GetKeyDown(KeyCode.D) && coyoteTime >= 0)
        {
            MoveToRight();
        }
        else if(Input.GetKeyDown(KeyCode.A) && coyoteTime >= 0)
        {
            MoveToLeft();
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
            //Resets the delay
            countDownToSummon = playerStats.holdToSummonTime;
            //Instantiates the summon
            Instantiate(summon, new Vector3(transform.position.x,transform.position.y - 3, 0), Quaternion.identity);
            //Starts the summon cooldown
            summonColldown = playerStats.coolDownSummoning;
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
}
