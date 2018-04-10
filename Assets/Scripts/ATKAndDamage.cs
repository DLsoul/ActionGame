using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKAndDamage : MonoBehaviour {
    public float hp = 100;
    public float normalAttack = 50;
    public float attackDistance = 1;
    public float awardExitTime = 10;
    public AudioClip deadSound;
    private Animator animator;

    protected void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    public virtual void TakeDamage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            if (hp > 0)
            {
                if (this.tag != Tags.Player)
                {
                    animator.SetTrigger("Damage");
                }
                
            }
            else
            {
                animator.SetBool("Dead", true);
                if (this.tag == Tags.soulBoss)
                {
                    AudioSource.PlayClipAtPoint(deadSound, transform.position, 0.8f);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(deadSound, transform.position, 0.4f);
                }
                
            }
        }
        else
        {
            animator.SetBool("Dead",true);
        }
        if (this.tag == Tags.soulBoss)
        {
            GameObject.Instantiate(Resources.Load("HitBoss"), transform.position+Vector3.up, transform.rotation);

        }
        else if (this.tag == Tags.soulMonster)
        {
            GameObject.Instantiate(Resources.Load("HitMonster"), transform.position+Vector3.up, transform.rotation);
        }
    }

    public void ReDeath()
    {
        animator.SetBool("Dead", false);
        SpawnMange._instance.enemyList.Remove(this.gameObject);
        AwardSpawn();
        if (this.tag != Tags.Player)
        {
            Destroy(this.gameObject, 1);
        }
        this.GetComponent<CharacterController>().enabled = false;
    }

    void AwardSpawn()
    {
        int count = Random.Range(0, 2);
        for(int i = 0; i <= count; i++)
        {
            int type = Random.Range(0, 2);
            if (type==0)
            {
                GameObject go=GameObject.Instantiate(Resources.Load("Item_Gun"), transform.position+Vector3.up,Quaternion.identity)as GameObject;
                Destroy(go, awardExitTime);
            }
            else if(type==1)
            {
                GameObject go=GameObject.Instantiate(Resources.Load("Item_DualSword"), transform.position + Vector3.up, Quaternion.identity)as GameObject;
                Destroy(go, awardExitTime);
            }
        }
    }
}
