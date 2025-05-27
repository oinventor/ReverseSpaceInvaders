using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCOntroller : MonoBehaviour
{
    public ScrbSummon summonStats;
    public AnimationClip animationCip;
    public GameObject[] explosions;
    [NonSerialized] public float damege;
    void Awake()
    {
        damege = summonStats.damegeDelt;
        if (summonStats.explosion != null)
        {
            AudioController.audioController.PlayAudioClip(summonStats.explosion, transform, 1f);
        }
        StartCoroutine(Expand());
        Destroy(this.gameObject, animationCip.length * 5);
    }

    private IEnumerator Expand()
    {
        foreach (GameObject explosion in explosions)
        {
            yield return new WaitForSeconds(animationCip.length);
            if (explosion != null)
            {
                explosion.SetActive(true);
                this.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
            }
        }

    }
}
