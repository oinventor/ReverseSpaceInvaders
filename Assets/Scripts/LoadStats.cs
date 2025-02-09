using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoadStats : MonoBehaviour
{
    public UnityEvent loadStats;
    void Awake()
    {
        loadStats.Invoke();
    }
}
