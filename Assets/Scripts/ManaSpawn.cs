using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSpawn : MonoBehaviour
{
    private int spawnChanceRand;
    private float spawnTimeCount;
    public ScrbSpawns manaSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Mana spawn
        spawnTimeCount += Time.deltaTime;
        if (spawnTimeCount >= manaSpawn.tempoDeSpawn && Time.timeScale != 0)
        {
            spawnTimeCount = 0;
            spawnChanceRand = 0;
            spawnChanceRand = Random.Range(1, manaSpawn.randMax+1);
            RaycastHit2D manaChec = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 2f), transform.TransformDirection(Vector2.down), 2f);
            if(manaChec.collider == null)
            {
                if (spawnChanceRand == 1)
                {
                    Instantiate(manaSpawn.spawn, new Vector3(transform.position.x,transform.position.y - 3, 0), Quaternion.identity);
                }
                else
                {

                }
            }
            else if(manaChec.collider.tag == "ManaBall")
            {

            }
            else
            {

            }
        }
        else
        {

        }
    }
}
