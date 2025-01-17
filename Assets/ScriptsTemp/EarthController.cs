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
    public static int curantHealth;
    private int chosenPlataform;
    private int nextPlataform;
    private float spawnCountTime;
    // Start is called before the first frame update
    void Start()
    {
        curantHealth = countryStats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountTime += Time.deltaTime;
        if (curantHealth > 0 && spawnCountTime >= countryStats.spawnTime || nextPlataform > 0)
        {
            spawnCountTime = 0;
            chosenPlataform = nextPlataform <= 0? Random.Range(1, 5 + 1): nextPlataform;
            SpawnTank(chosenPlataform);
        }
        else if(curantHealth <= 0)
        {
            RaycastHit2D plataformChec1 = Physics2D.Raycast(spawnPlataform1.transform.position, transform.TransformDirection(Vector2.up), 2f);
            RaycastHit2D plataformChec2 = Physics2D.Raycast(spawnPlataform2.transform.position, transform.TransformDirection(Vector2.up), 2f);
            RaycastHit2D plataformChec3 = Physics2D.Raycast(spawnPlataform3.transform.position, transform.TransformDirection(Vector2.up), 2f);
            RaycastHit2D plataformChec4 = Physics2D.Raycast(spawnPlataform4.transform.position, transform.TransformDirection(Vector2.up), 2f);
            RaycastHit2D plataformChec5 = Physics2D.Raycast(spawnPlataform5.transform.position, transform.TransformDirection(Vector2.up), 2f);

            if (plataformChec1.collider == null && plataformChec2.collider == null && plataformChec3.collider == null &&
                plataformChec4.collider == null && plataformChec5.collider == null)
            {
                Time.timeScale = 0;
                Destroy(GameObject.FindWithTag("Player").GetComponent<PlayerController>());
                onVictory.Invoke();
            }
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
                    curantHealth -= countryStats.healthPerSummon;
                    Instantiate(countryStats.tank, spawnPlataform1.transform.position, Quaternion.identity);
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
                    curantHealth -= countryStats.healthPerSummon;
                    Instantiate(countryStats.tank, spawnPlataform2.transform.position, Quaternion.identity);
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
                    curantHealth -= countryStats.healthPerSummon;
                    Instantiate(countryStats.tank, spawnPlataform3.transform.position, Quaternion.identity);
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
                    curantHealth -= countryStats.healthPerSummon;
                    Instantiate(countryStats.tank, spawnPlataform4.transform.position, Quaternion.identity);
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
                    curantHealth -= countryStats.healthPerSummon;
                    Instantiate(countryStats.tank, spawnPlataform5.transform.position, Quaternion.identity);
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
}
