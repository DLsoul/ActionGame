using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    private GameObject player;
    private CharacterController cc;
    private Animator animator;
    public float speed = 2;
    public float attackDistance = 2;
    public float attackTime = 3;
    private float attackTimer = 0;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
        cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
        attackTimer = attackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerATKAndDamage>().hp <= 0)
        {
            animator.SetBool("Walk", false);
            return;
        }
        Vector3 targetPos = player.transform.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance <= attackDistance)
        {
            
            attackTimer += Time.deltaTime;
            if (attackTimer > attackTime)
            {
                animator.SetTrigger("Attack");
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
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))
            {
                cc.SimpleMove(transform.forward * speed);
            }
            animator.SetBool("Walk", true);
        }
    }
}
