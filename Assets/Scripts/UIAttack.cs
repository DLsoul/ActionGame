using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAttack : MonoBehaviour {
    public static UIAttack _instance;
    public GameObject Normal;
    public GameObject Range;
    public GameObject Red;


	void Awake () {
        _instance = this;
        Normal = GameObject.Find("NormalAttack").gameObject;
        Range = GameObject.Find("RangeAttack").gameObject;
        Red = GameObject.Find("RedAttack").gameObject;
    }

    public void OneCon()
    {
        Normal.SetActive(false);
        Range.SetActive(false);
        Red.SetActive(true);
    }

    public void TwoCon()
    {
        Normal.SetActive(true);
        Range.SetActive(true);
        Red.SetActive(false);
    }
}
