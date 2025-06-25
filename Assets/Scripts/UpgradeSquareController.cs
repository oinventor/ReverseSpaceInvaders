using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
public class UpgradeSquareController : MonoBehaviour
{
    public ScrbUpgradePool upgradePool;
    public TextMeshProUGUI description;
    private Upgrade chosenUpgrade;
    public UnityEvent selectUpgrade;
    public GameObject pauseManue;
    // Start is called before the first frame update
    void OnEnable()
    {
        chosenUpgrade = upgradePool.ChoseUpgrade();
        if (chosenUpgrade != null)
        {
            description.text = chosenUpgrade.description;
        }
    }

    void OnMouseOver()
    {
        if (chosenUpgrade == null)
        {
            return;
        }
        if (Input.GetMouseButtonUp(0))
        {
            chosenUpgrade.UpdateStats();
            chosenUpgrade.aquisitionCounter++;
            if (chosenUpgrade.removeAfterAquisition == true && chosenUpgrade.aquisitionCounter >= chosenUpgrade.aquisitionTimes)
            {
                upgradePool.removedUpgradePoolList.Remove(chosenUpgrade);
            }
            upgradePool.AddUpgrades();
            selectUpgrade.Invoke();
        }
    }

    void Update()
    {
        switch (pauseManue.activeSelf)
        {
            case true:
                this.GetComponent<BoxCollider2D>().enabled = false;
            break;
            default:
                this.GetComponent<BoxCollider2D>().enabled = true;
            break;
        }
    }
}
