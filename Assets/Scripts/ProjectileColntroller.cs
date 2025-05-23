using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ProjectileColntroller : MonoBehaviour
{
    private float movimentCooldownTime;
    public int damege;
    public ScrbSummon projectileStats;
    // Start is called before the first frame update
    void Start()
    {
        if (projectileStats.spawning != null)
        {
            AudioController.audioController.PlayAudioClip(projectileStats.spawning, transform, 1f);
        }
        damege = (int)projectileStats.damegeDelt;
        this.transform.position += new Vector3(0, projectileStats.movimentoVertical,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (projectileStats.updateBool == true)
        {
            damege = (int)projectileStats.damegeDelt;
            projectileStats.updateBool = false;
        }
        //Increases the cooldown time
        movimentCooldownTime += Time.deltaTime;
        //So then when the cooldown reaches the trashold set by the Scrb
        switch (movimentCooldownTime >= projectileStats.coolDownMovimento)
        {
            //It will move to a certan horizontal direction
            case true:
                this.transform.position += transform.up * projectileStats.movimentoVertical;
                movimentCooldownTime = 0;
            break;
            default:
            break;
        }
    }
    void OnTriggerEnter2D(Collider2D objColls)
    {
        switch (objColls.gameObject.tag)
        {
            case "Player":
                Destroy(this.gameObject);
            break;
            case "Shield":
                Destroy(this.gameObject);
            break;
            case "DestroyBarier":
                Destroy(this.gameObject);
            break;
            case "Summon":
                objColls.gameObject.GetComponent<SumomController>().TakeDamege(damege);
                Destroy(this.gameObject);
            break;
            case "SupperSummon":
                objColls.gameObject.GetComponent<SuperSummonController>().TakeDamege(damege);
                Destroy(this.gameObject);
            break;
            case "MidSummon":
                objColls.gameObject.GetComponent<MidSummonController>().TakeDamege(damege);
                Destroy(this.gameObject);
            break;
            default:
            break;
        }
    }
}
