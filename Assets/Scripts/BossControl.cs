using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    private Transform player;
    private CharacterController cc;
    private Animator animator;
    public float speed = 2;
    public float attackDistance = 2;
    public float attackTime = 3;
    private float attackTimer = 0;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
        attackTimer = attackTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance <= attackDistance)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > attackTime)
            {
                int num = Random.Range(0, 2);
                if (num == 0){
                    animator.SetTrigger("Attack1");
                }
                else
                {
                    animator.SetTrigger("Attack2");
                }
                attackTimer = 0;
            }
            else
            {
                animator.SetBool("Walk", false);
            }

        }
        else
        {
            attackTimer = attackTime;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("BossRun01"))
            {
                cc.SimpleMove(transform.forward * speed);
            }
            animator.SetBool("Walk", true);
        }
    }
}
