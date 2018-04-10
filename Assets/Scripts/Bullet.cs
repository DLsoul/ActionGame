using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 20;
    public float attack = 100;
    public float exitTime = 2;
    private void Start()
    {
        Destroy(this.gameObject, exitTime);
    }

    void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.soulBoss || col.tag == Tags.soulMonster)
        {
            col.GetComponent<ATKAndDamage>().TakeDamage(attack);
        }
    }
}
