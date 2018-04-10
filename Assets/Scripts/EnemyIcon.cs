using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIcon : MonoBehaviour {

    private Transform player;
    private Transform icon;

	// Use this for initialization
	void Start () {
        if (this.tag == Tags.soulBoss)
        {
            icon = MiniMap._instance.GetBossIcon().transform;
        }else if (this.tag == Tags.soulMonster)
        {
            icon = MiniMap._instance.GetMonIcon().transform;
        }
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = transform.position - player.position;
        offset *= 10;
        icon.localPosition = new Vector3(offset.x, offset.z, 0);
	}

    private void OnDestroy()
    {
        if (icon != null)
        {
            Destroy(icon.gameObject);
        }
    }
}
