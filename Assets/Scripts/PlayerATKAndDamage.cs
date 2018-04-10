using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATKAndDamage : ATKAndDamage {
    public float attackB=80;
    public float attackGun=70;
    public float attackRange=100;
    public WeaponGun gun;
    public AudioClip gunSound;
    public AudioClip swordSound;
    public void AttackA()
    {
        AudioSource.PlayClipAtPoint(swordSound, transform.position, 1f);
        GameObject enemy = null;
        float distance = attackDistance;
        foreach(GameObject go in SpawnMange._instance.enemyList)
        {
            float temp = Vector3.Distance(go.transform.position, transform.position);
            if (temp < distance)
            {
                enemy = go;
                distance = temp;
            }
        }
        if (enemy)
        {
            Vector3 tarPos = enemy.transform.position;
            tarPos.y = transform.position.y;
            transform.LookAt(tarPos);
            enemy.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }

    public void AttackB()
    {
        AudioSource.PlayClipAtPoint(swordSound, transform.position, 1f);
        GameObject enemy = null;
        float distance = attackDistance;
        foreach (GameObject go in SpawnMange._instance.enemyList)
        {
            float temp = Vector3.Distance(go.transform.position, transform.position);
            if (temp < distance)
            {
                enemy = go;
                distance = temp;
            }
        }
        if (enemy)
        {
            Vector3 tarPos = enemy.transform.position;
            tarPos.y = transform.position.y;
            transform.LookAt(tarPos);
            enemy.GetComponent<ATKAndDamage>().TakeDamage(attackB);
        }
    }

    public void AttackRange()
    {
        AudioSource.PlayClipAtPoint(swordSound, transform.position, 1f);
        float distance = attackDistance;
        List<GameObject> enemyList = new List<GameObject>();
        foreach (GameObject go in SpawnMange._instance.enemyList)
        {
            float temp = Vector3.Distance(go.transform.position, transform.position);
            if (temp < distance)
            {
                enemyList.Add(go);
            }
        }
        foreach(GameObject go in enemyList)
        {
            go.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
        }
    }

    public void AttackGun()
    {
        gun.attack = attackGun;
        gun.shoot();
        AudioSource.PlayClipAtPoint(gunSound, transform.position, 1f);
    }
}
