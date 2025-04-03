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
            selectUpgrade.Invoke();
        }
    }
}
