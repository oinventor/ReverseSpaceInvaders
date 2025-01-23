using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    public ScrbSummon turretaQueSegue;
    private Transform target;
    private float enemyAimSpeed = 5.0f;
    Quaternion newRotation;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        newRotation = Quaternion.LookRotation (transform.position - target.position, Vector3.forward);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.Lerp (transform.rotation,newRotation,Time.deltaTime * enemyAimSpeed);
    }
}
