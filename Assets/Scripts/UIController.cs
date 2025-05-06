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
    public Material healthTex;
    public Material manaTex;
    public Material emptyHealthTex;
    public Material emptyManaTex;
    public float startFadeOutTime;
    public float fadeOutTimeDuration;
    public float transparencySubtraction;
    private float heathSliderSize;
    private float manaSliderSize;
    private float heathSegments;
    private float manaSegments;
    private float emptyHeathSegments;
    private float emptyManaSegments;
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
        heathSegments = healthTex.GetFloat("_segments");
        manaSegments = manaTex.GetFloat("_segments");
        emptyHeathSegments = heathSegments;
        emptyManaSegments = manaSegments;
        heathSliderSize = healthBar.transform.localScale.x / (float)maxHealth;
        manaSliderSize = manaBar.transform.localScale.x / (float)maxMana;
        points.text = "";
        level.text = "";
        StartCoroutine(StartFadeOut());
    }
    void Update()
    {
        healthTex.SetFloat("_segments", maxHealth);
        manaTex.SetFloat("_segments", maxMana);
        emptyHealthTex.SetFloat("_segments", maxHealth);
        emptyManaTex.SetFloat("_segments", maxMana);
        emptyHeathSegments = heathSegments;
        emptyManaSegments = manaSegments;
        healthBar.transform.localScale = new Vector3 ( heathSliderSize * (float)maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        manaBar.transform.localScale = new Vector3 (manaSliderSize * (float)maxMana, manaBar.transform.localScale.y, manaBar.transform.localScale.z);

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

    public void LoadSegments()
    {

        //healthBar.transform.localScale = new Vector3 ((float)heathSliderSize * (float)maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        //manaBar.transform.localScale = new Vector3 ((float)manaSliderSize * (float)maxMana, manaBar.transform.localScale.y, manaBar.transform.localScale.z);
        healthTex.SetFloat("_segments", maxHealth);
        manaTex.SetFloat("_segments", maxMana);
        emptyHealthTex.SetFloat("_segments", maxHealth);
        emptyManaTex.SetFloat("_segments", maxMana);
    }
}
