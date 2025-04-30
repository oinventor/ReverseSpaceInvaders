using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Slider chargeBar;
    public Slider manaBar;
    public Slider healthBar;
    public Slider shieldCooldown;
    public TextMeshProUGUI points;
    public TextMeshProUGUI level;
    private GameObject player;
    public Image tutorial;
    public float startFadeOutTime;
    public float fadeOutTimeDuration;
    public float transparencySubtraction;
    private int maxHealth;
    private int curantHealth;
    private float curantCharge;
    private float maxShieldCooldown;
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
        maxShieldCooldown = player.GetComponent<PlayerController>().playerStats.shieldCooldown;
        chargeBar.maxValue = maxCharge;
        manaBar.maxValue = maxMana;
        healthBar.maxValue = maxHealth;
        shieldCooldown.maxValue = maxShieldCooldown;
        points.text = "";
        level.text = "";
        StartCoroutine(StartFadeOut());
    }
    void Update()
    {
        maxHealth = player.GetComponent<PlayerController>().playerStats.maxHealth;
        maxMana = player.GetComponent<PlayerController>().playerStats.maxMana;
        maxCharge = player.GetComponent<PlayerController>().playerStats.holdToSuperSummonTime;
        maxShieldCooldown = player.GetComponent<PlayerController>().playerStats.shieldCooldown;
        chargeBar.maxValue = maxCharge;
        manaBar.maxValue = maxMana;
        healthBar.maxValue = maxHealth;
        shieldCooldown.maxValue = maxShieldCooldown;

        shieldCooldown.value = maxShieldCooldown - PlayerController.shieldCooldown;
        chargeBar.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 4);
        newMana = PlayerController.curentMana;
        manaBar.value = newMana;
        curantCharge = PlayerController.countDownToSummon;
        chargeBar.value = curantCharge;
        curantHealth = PlayerController.curantHealth;
        healthBar.value = curantHealth;
        points.text = PointsAndLevelController.points.ToString();
        level.text = PointsAndLevelController.levels.ToString();
    }

    IEnumerator StartFadeOut()
    {
        yield return new WaitForSeconds(startFadeOutTime);
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        for (float aFactor = 1f; aFactor >= -0.001f; aFactor -= transparencySubtraction)
        {
            Color transparency = tutorial.color;
            transparency.a = aFactor;
            tutorial.color = transparency;
            yield return new WaitForSeconds(fadeOutTimeDuration * Time.deltaTime);
        }
    }
}
