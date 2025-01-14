using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumomController : MonoBehaviour
{
    private float movimentColldownTime;
    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        switch (this.transform.position.x >0)
        {
            case true:
                direction = -1;
            break;
            default:
                direction = 1;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movimentColldownTime += Time.deltaTime;
        switch (movimentColldownTime >= 0.5f)
        {
            case true:
                HorizontalMovement();
            break;
            default:
            break;
        }
        if (this.transform.position.x < -13 && direction == -1)
        {
            StartCoroutine(VerticalMovement());
            direction *=-1f;
        }
        else if (this.transform.position.x > 13 && direction == 1)
        {
            StartCoroutine(VerticalMovement());
            direction *=-1f;
        }
        else
        {

        }
    }
    void HorizontalMovement()
    {
        movimentColldownTime = 0;
        this.transform.position += new Vector3(2f*direction,0,0);
    }
    IEnumerator VerticalMovement()
    {
        movimentColldownTime = -0.5f;
        yield return new WaitForSeconds(0.5f);
        this.transform.position += new Vector3(0,-2f,0);
    }
}

