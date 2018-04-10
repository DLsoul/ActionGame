using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAward : MonoBehaviour {
    public GameObject singSword;
    public GameObject dualSword;
    public GameObject gun;
    public float dualSwordTimer = 0;
    public float gunTimer = 0;
    public float exitTime = 10;
    //public List<GameObject> weapons;
    //private void Awake()
    //{
    //    weapons.Add(gun);
    //    weapons.Add(dualSword);
    //    weapons.Add(singSword);
    //}
    private void Update()
    {
        if (dualSwordTimer > 0)
        {
            dualSwordTimer -= Time.deltaTime;
            if (dualSwordTimer <= 0)
            {
                TurnSingSword();
            }
        }

        if (gunTimer > 0)
        {
            gunTimer -= Time.deltaTime;
            if (gunTimer <= 0)
            {
                TurnSingSword();
            }
        }
    }

    public void GetAward(AwardType type)
    {
        if (type == AwardType.Gun)
        {
            TurnGun();
        }
        if (type == AwardType.DualSword)
        {
            TurnDualSword();
        }
        //TurnWeapon(type);
    }

    void TurnGun()
    {
        singSword.SetActive(false);
        gun.SetActive(true);
        dualSword.SetActive(false);
        gunTimer = exitTime;
        UIAttack._instance.OneCon();
    }

    void TurnDualSword()
    {
        singSword.SetActive(false);
        gun.SetActive(false);
        dualSword.SetActive(true);
        dualSwordTimer = exitTime;
        UIAttack._instance.TwoCon();
    }

    void TurnSingSword()
    {
        singSword.SetActive(true);
        gun.SetActive(false);
        dualSword.SetActive(false);
        UIAttack._instance.TwoCon();
    }

    //void TurnWeapon(AwardType type)
    //{
    //    for(int i = 0; i < weapons.Count; i++)
    //    {
    //        if (type== (AwardType)i)
    //        {
    //            weapons[i].SetActive(true);
    //        }
    //        else
    //        {
    //            weapons[i].SetActive(false);
    //        }
    //    }
    //}
}
