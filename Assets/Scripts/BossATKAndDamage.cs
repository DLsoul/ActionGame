using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossATKAndDamage : ATKAndDamage {

    public float attack2 = 100;
    private Transform player;
    public AudioClip attackSound;
    private new void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
    }

    public void BossAttack1()
    {
        if (Vector3.Distance(player.position, this.transform.position)<attackDistance)
        {
            AudioSource.PlayClipAtPoint(attackSound, transform.position, 1f);
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }

    public void BossAttack2()
    {
        if (Vector3.Distance(player.position, this.transform.position) < attackDistance)
        {
            AudioSource.PlayClipAtPoint(attackSound, transform.position, 1f);
            player.GetComponent<ATKAndDamage>().TakeDamage(attack2);
        }
    }
}
