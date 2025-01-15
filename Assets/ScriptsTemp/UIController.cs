using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Slider manaBar;
    private float newMana;
    private float maxMana;
    // Start is called before the first frame update
    void Start()
    {
        maxMana = GameObject.FindWithTag("Player").GetComponent<PlayerController>().playerStats.maxMana;
        manaBar.maxValue = maxMana;
    }
    void Update()
    {
        newMana = PlayerController.curentMana;
        manaBar.value = newMana;
    }
}
