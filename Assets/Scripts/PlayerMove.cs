using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    private CharacterController character;
    private Animator animator;
    public float speed = 4;
	// Use this for initialization
	void Awake () {
        character = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
	}
    // Update is called once per frame
    void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(h)>0.1f||Mathf.Abs(v)>0.1f)
        {
            animator.SetBool("Walk", true);
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
            {
                Vector3 targetDir = new Vector3(h, 0, v);
                transform.LookAt(targetDir + transform.position);
                float trueSpeed = speed;
                if (Input.GetKey(KeyCode.Space))
                {
                    trueSpeed = speed + 3;
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    character.Move(transform.forward * 3);
                }
                character.SimpleMove(transform.forward * trueSpeed);
            }
        }
        else
        {
            animator.SetBool("Walk", false);
        }
	}
}
