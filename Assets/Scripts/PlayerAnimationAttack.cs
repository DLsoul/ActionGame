using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationAttack : MonoBehaviour {
    private Animator animator;
    private CharacterController character;
    private bool isCanAttackB;

    //public WeaponTrail myTrail;
    //private float t = 0.033f;
    //private float tempT = 0;
    //private float animationIncrement = 0.003f;
    // Use this for initialization
    void Start () {
        //myTrail.SetTime(0.0f, 0.0f, 1.0f);
        animator = gameObject.GetComponent<Animator>();
        character = this.GetComponent<CharacterController>();
        EventDelegate NormalAttackEvent = new EventDelegate(this, "OnNormalAttackClick");
        GameObject.Find("NormalAttack").GetComponent<UIButton>().onClick.Add(NormalAttackEvent);

        EventDelegate RangeAttackEvent = new EventDelegate(this, "OnRangeAttackClick");
        GameObject.Find("RangeAttack").GetComponent<UIButton>().onClick.Add(RangeAttackEvent);

        EventDelegate RedAttackEvent = new EventDelegate(this, "OnRedAttackClick");
        //GameObject.Find("RedAttack").GetComponent<UIButton>().onClick.Add(RedAttackEvent);
        GameObject redAttack = GameObject.Find("RedAttack");
        redAttack.GetComponent<UIButton>().onClick.Add(RedAttackEvent);
        redAttack.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.J))
        {
            OnNormalAttackClick();
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            OnRangeAttackClick();
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            OnRedAttackClick();
        }
    }

    //void LateUpdate()
    //{
    //    t = Mathf.Clamp(Time.deltaTime, 0, 0.066f);

    //    if (t > 0)
    //    {
    //        while (tempT < t)
    //        {
    //            tempT += animationIncrement;

    //            if (myTrail.time > 0)
    //            {
    //                myTrail.Itterate(Time.time - t + tempT);
    //            }
    //            else
    //            {
    //                myTrail.ClearTrail();
    //            }
    //        }

    //        tempT -= t;

    //        if (myTrail.time > 0)
    //        {
    //            myTrail.UpdateTrail(Time.time, t);
    //        }
    //    }
    //}

    public void OnNormalAttackClick()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA")&&isCanAttackB==true)
        {
            animator.SetTrigger("AttackB");
        }
        else
        {
            animator.SetTrigger("AttackA");
        }
        
    }
    public void OnRangeAttackClick()
    {
        animator.SetTrigger("AttackRange");
    }
    public void OnRedAttackClick()
    {
        animator.SetTrigger("AttackGun");
    }

    public void AttackBEvent1()
    {
        isCanAttackB = true;
    }
    public void AttackBEvent2()
    {
        isCanAttackB = false;
    }

    //public void SingTrailStart()
    //{
    //    //设置拖尾时长
    //    myTrail.SetTime(2.0f, 0.0f, 1.0f);
    //    //开始进行拖尾
    //    myTrail.StartTrail(0.5f, 0.4f);
    //}

    //public void SingTrailEnd()
    //{
    //    myTrail.ClearTrail();
    //}

    //public void AttackBTrailStart()
    //{
    //    //设置拖尾时长
    //    myTrail.SetTime(2.0f, 0.0f, 1.0f);
    //    //开始进行拖尾
    //    myTrail.StartTrail(0.5f, 0.4f);
    //}

    //public void AttackBTrailEnd()
    //{
    //    myTrail.ClearTrail();
    //}
}
