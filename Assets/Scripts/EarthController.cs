using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EarthController : MonoBehaviour
{
    public UnityEvent onVictory;

    public ScrbCountry countryStats;
    public GameObject spawnPlataform1;
    public GameObject spawnPlataform2;
    public GameObject spawnPlataform3;
    public GameObject spawnPlataform4;
    public GameObject spawnPlataform5;
    private GameObject spawnable;
    private int chosenPlataform;
    private int nextPlataform;
    private float spawnCountTime;
    private bool firstSpawn;
    // Start is called before the first frame update
    void Start()
    {
        firstSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountTime += Time.deltaTime;
        if (firstSpawn == true && spawnCountTime >= countryStats.startSpawnTime)
        {
            firstSpawn = false;
            spawnCountTime = countryStats.spawnTime;
        }
        if (spawnCountTime >= countryStats.spawnTime || nextPlataform > 0)
        {
            spawnCountTime = 0;
            chosenPlataform = nextPlataform <= 0? Random.Range(1, 5 + 1): nextPlataform;
            int whatSpawnable = Random.Range(1, 3 + 1);
            switch (whatSpawnable)
            {
                case 1:
                spawnable = countryStats.inimigo1;
                break;
                case 2:
                spawnable = countryStats.inimigo2;
                break;
                default:
                spawnable = countryStats.inimigo3;
                break;
            }
            SpawnTank(chosenPlataform);
        }
    }
    void SpawnTank(int chosenPlataform)
    {
        switch (chosenPlataform)
        {
            case 1:
                RaycastHit2D plataformChec1 = Physics2D.Raycast(spawnPlataform1.transform.position, transform.TransformDirection(Vector2.up), 2f);
                if (plataformChec1.collider != null)
                {
                    Debug.Log("p1 cheia");
                    nextPlataform++;
                }
                else
                {
                    Instantiate(spawnable, spawnPlataform1.transform.position, Quaternion.identity);
                    nextPlataform = 0;
                    spawnCountTime = 0;
                }
            break;
            case 2:
                RaycastHit2D plataformChec2 = Physics2D.Raycast(spawnPlataform2.transform.position, transform.TransformDirection(Vector2.up), 2f);
                if (plataformChec2.collider != null)
                {
                    Debug.Log("p2 cheia");
                    nextPlataform++;
                }
                else
                {
                    Instantiate(spawnable, spawnPlataform2.transform.position, Quaternion.identity);
                    nextPlataform = 0;
                    spawnCountTime = 0;
                }
            break;
            case 3:
                RaycastHit2D plataformChec3 = Physics2D.Raycast(spawnPlataform3.transform.position, transform.TransformDirection(Vector2.up), 2f);
                if (plataformChec3.collider != null)
                {
                    Debug.Log("p3 cheia");
                    nextPlataform++;
                }
                else
                {
                    Instantiate(spawnable, spawnPlataform3.transform.position, Quaternion.identity);
                    nextPlataform = 0;
                    spawnCountTime = 0;
                };
            break;
            case 4:
                RaycastHit2D plataformChec4 = Physics2D.Raycast(spawnPlataform4.transform.position, transform.TransformDirection(Vector2.up), 2f);
                if (plataformChec4.collider != null)
                {
                    Debug.Log("p4 cheia");
                    nextPlataform++;
                }
                else
                {
                    Instantiate(spawnable, spawnPlataform4.transform.position, Quaternion.identity);
                    nextPlataform = 0;
                    spawnCountTime = 0;
                }
            break;
            case 5:
                RaycastHit2D plataformChec5 = Physics2D.Raycast(spawnPlataform5.transform.position, transform.TransformDirection(Vector2.up), 2f);
                if (plataformChec5.collider != null)
                {
                    Debug.Log("p5 cheia");
                    nextPlataform++;
                }
                else
                {
                    Instantiate(spawnable, spawnPlataform5.transform.position, Quaternion.identity);
                    nextPlataform = 0;
                    spawnCountTime = 0;
                }
            break;
            case 6:
                Debug.Log("no space");
                nextPlataform = 0;
                spawnCountTime = 0;
            break;
            default:
            break;
        }
    }

    public static void TakeDamege()
    {
        PointsAndLevelController.AddPoints("earth");
    }
}
