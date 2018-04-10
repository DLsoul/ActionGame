using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterATKAndDamage : ATKAndDamage {
    private Transform player;
    private new void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
    }

    public void Attack()
    {
        if (Vector3.Distance(transform.position, player.position)<attackDistance)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
        
    }
}
