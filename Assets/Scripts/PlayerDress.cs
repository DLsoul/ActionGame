using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDress : MonoBehaviour {
    public SkinnedMeshRenderer[] body;
    public SkinnedMeshRenderer headRenderer;
    public SkinnedMeshRenderer handRenderer;
	// Use this for initialization
	void Start () {
        initDress();
	}
	
	void initDress()
    {
        int headIndex = PlayerPrefs.GetInt("headIndex");
        int handIndex = PlayerPrefs.GetInt("handIndex");
        int colorIndex = PlayerPrefs.GetInt("colorIndex");

        headRenderer.sharedMesh = MenuControl._instance.head[headIndex];
        handRenderer.sharedMesh = MenuControl._instance.hand[handIndex];
        foreach(SkinnedMeshRenderer render in body)
        {
            render.material.color = MenuControl._instance.colorArray[colorIndex];
        }
    }
}
