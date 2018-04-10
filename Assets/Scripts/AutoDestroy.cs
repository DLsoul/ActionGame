using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {
    public float exitTime=1;
    private void Start()
    {
        Destroy(this.gameObject, exitTime);
    }
}
