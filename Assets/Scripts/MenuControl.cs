using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour {
    public static MenuControl _instance;
    public SkinnedMeshRenderer[] body;
    public Color purple;
    public SkinnedMeshRenderer headRenderer;
    public Mesh[] head;
    private int headIndex = 0;

    public SkinnedMeshRenderer handRenderer;
    public Mesh[] hand;
    private int handIndex = 0;
    [HideInInspector]
    public Color[] colorArray;
    private int colorIndex=-1;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        colorArray = new Color[] { Color.blue,Color.cyan,Color.red,Color.green,purple};
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnHeadMeshNext()
    {
        headIndex++;
        headIndex %= head.Length;
        headRenderer.sharedMesh = head[headIndex];
    }

    public void OnHandMeshNext()
    {
        handIndex++;
        handIndex %= hand.Length;
        handRenderer.sharedMesh = hand[handIndex];
    }

	public void OnChangeColorBlue(){
        colorIndex = 0;
        OnChangeColor(Color.blue);
    }

    public void OnChangeColorCyan()
    {
        colorIndex = 1;
        OnChangeColor(Color.cyan);
    }

    public void OnChangeColorRed()
    {
        colorIndex = 2;
        OnChangeColor(Color.red);
    }

    public void OnChangeColorGreen()
    {
        colorIndex = 3;
        OnChangeColor(Color.green);
    }

    public void OnChangeColorPurple()
    {
        colorIndex = 4;
        OnChangeColor(purple);
    }

    private void OnChangeColor(Color c)
    {
        foreach(SkinnedMeshRenderer renderer in body){
            renderer.material.color = c;
        }
    }

    private void save()
    {
        PlayerPrefs.SetInt("headIndex", headIndex);
        PlayerPrefs.SetInt("handIndex", handIndex);
        PlayerPrefs.SetInt("colorIndex", colorIndex);
    }

    public void OnPlay()
    {
        save();
#pragma warning disable CS0618 // 类型或成员已过时
        Application.LoadLevel(1);
#pragma warning restore CS0618 // 类型或成员已过时
    }
}
