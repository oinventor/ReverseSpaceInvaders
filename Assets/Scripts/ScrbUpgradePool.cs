using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade Pool", menuName = "Scrbs/Upgrade Pool")]
public class ScrbUpgradePool : ScriptableObject
{
    public Upgrade[] upgradePool;
    [NonSerialized]
    public List<Upgrade> upgradePoolList;
    [NonSerialized]
    public List<Upgrade> removedUpgradePoolList;
    private Upgrade chosenUpgrade;
    public void LoadUpgrade()
    {
        upgradePoolList = new List<Upgrade>();
        removedUpgradePoolList = new List<Upgrade>();
        upgradePoolList.Clear();
        foreach(Upgrade upgrade in upgradePool)
        {
            upgradePoolList.Add(upgrade);
        }
    }

    public Upgrade ChoseUpgrade()
    {
        if (upgradePoolList.Count <= 0)
        {
            Debug.Log("Upgrades exhausted");
            return null;
        }
        int upgradeRandomizer = UnityEngine.Random.Range(0, upgradePoolList.Count);
        chosenUpgrade = upgradePoolList[upgradeRandomizer];
        upgradePoolList.Remove(chosenUpgrade);
        removedUpgradePoolList.Add(chosenUpgrade);
        return chosenUpgrade;
    }
    public void AddUpgrades()
    {
        foreach(Upgrade upgrade in removedUpgradePoolList)
        {
            if (removedUpgradePoolList.Count <= 0)
            {
                break;
            }
            upgradePoolList.Add(upgrade);

        }
        removedUpgradePoolList.Clear();
    }
}
