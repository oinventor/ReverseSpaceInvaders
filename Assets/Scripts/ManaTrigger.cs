using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManaTrigger : MonoBehaviour
{
    public UnityEvent onManaTrigger;
    void OnTriggerEnter2D(Collider2D playerColl)
    {
        switch (playerColl.gameObject.tag == "Player")
        {
            case true:
                onManaTrigger.Invoke();
                onManaTrigger.RemoveAllListeners();
                Destroy(this.gameObject);
                break;
            default:
            break;
        }
    }
}
