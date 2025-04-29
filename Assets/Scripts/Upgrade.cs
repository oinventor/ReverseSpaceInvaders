using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : ScriptableObject
{
    [Header("Updade Configs")]
    public bool removeAfterAquisition;
    public int aquisitionTimes;
    [TextArea(3, 10)]
    public string description;
    [NonSerialized]
    public int aquisitionCounter;
    public virtual void UpdateStats()
    {

    }
}
