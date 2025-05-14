using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : ScriptableObject
{
    [Header("Updade Configs")]
    public bool removeAfterAquisition;
    public int aquisitionTimes;
    public UnityEngine.UI.Image icon;
    public string upgradeName;
    [TextArea(3, 10)]
    public string description;
    [NonSerialized]
    public int aquisitionCounter;
    public virtual void UpdateStats()
    {

    }
}
