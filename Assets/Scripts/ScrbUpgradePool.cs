using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade Pool", menuName = "Scrbs/Upgrade Pool")]
public class ScrbUpgradePool : ScriptableObject
{
    public Upgrade[] upgradePool;
    private List<Upgrade> upgradePoolList;
    private Upgrade chosenUpgrade;
    public void LoadUpgrade()
    {
        upgradePoolList = new List<Upgrade>();
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
        int upgradeRandomizer = Random.Range(0, upgradePoolList.Count);
        chosenUpgrade = upgradePoolList[upgradeRandomizer];
        return chosenUpgrade;
    }
}
