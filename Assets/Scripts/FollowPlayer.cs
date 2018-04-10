using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    private Transform player;
    //public AudioClip bgm;
    public float speed=3;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //AudioSource.PlayClipAtPoint(bgm, transform.position, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPos =player.position + new Vector3(0.15f, 2f, -3f);
        transform.position = Vector3.Lerp(transform.position,targetPos,speed*Time.deltaTime);
        Quaternion targetRotate = Quaternion.LookRotation(player.position-transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotate,speed*Time.deltaTime);
	}
}
