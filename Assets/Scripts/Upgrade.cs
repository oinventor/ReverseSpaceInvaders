using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : ScriptableObject
{
    [Header("Updade Description")]
    [TextArea(3, 10)]
    public string description;
    public virtual void UpdateStats()
    {

    }
}
