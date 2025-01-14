using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private float movimento;
    private Rigidbody2D playerRig;
    public GameObject summon;
    private float summonColldown;
    public ScrbPlayer playerStats;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = new Vector3(0, 10f, 0);
        playerRig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimento = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.D))
        {
            RaycastHit2D rightLane = Physics2D.Raycast(new Vector2(transform.position.x + 3, transform.position.y), transform.TransformDirection(Vector2.right), 10f);
            if (rightLane.collider.gameObject.tag == "Lane")
            {
                transform.position = rightLane.collider.gameObject.transform.position;
            }
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit2D leftLane = Physics2D.Raycast(new Vector2(transform.position.x - 3, transform.position.y), transform.TransformDirection(Vector2.left), 10f);
            if (leftLane.collider.gameObject.tag == "Lane")
            {
                transform.position = leftLane.collider.gameObject.transform.position;
            }
        }

        switch (Input.GetKeyDown(KeyCode.Space) && summonColldown <= 0)
        {
            case true:
                Instantiate(summon, new Vector3(transform.position.x,transform.position.y - 3, 0), Quaternion.identity);
                summonColldown = playerStats.coolDownSummoning;
            break;
            default:
            break;
        }

        if (summonColldown > 0)
        {
            summonColldown -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        //this.gameObject.transform.position += new Vector3(movimento*Time.deltaTime*10, 0, 0);
    }
}
