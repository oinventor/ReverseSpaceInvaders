using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Slider chargeBar;
    public Slider manaBar;
    public Slider healthBar;
    private GameObject player;
    private int maxHealth;
    private int curantHealth;
    private float curantCharge;
    private float maxCharge;
    private float newMana;
    private float maxMana;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        maxHealth = player.GetComponent<PlayerController>().playerStats.maxHealth;
        maxMana = player.GetComponent<PlayerController>().playerStats.maxMana;
        maxCharge = player.GetComponent<PlayerController>().playerStats.holdToSuperSummonTime;
        chargeBar.maxValue = maxCharge;
        manaBar.maxValue = maxMana;
        healthBar.maxValue = maxHealth;

    }
    void Update()
    {
        chargeBar.transform.position = Camera.main.WorldToScreenPoint(new Vector3(player.transform.position.x, player.transform.position.y - 3));
        newMana = PlayerController.curentMana;
        manaBar.value = newMana;
        curantCharge = PlayerController.countDownToSummon;
        chargeBar.value = curantCharge;
        curantHealth = PlayerController.curantHealth;
        healthBar.value = curantHealth;
    }
}
