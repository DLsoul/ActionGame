using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {
    public static MiniMap _instance;
    private Transform playerIcon;
    public GameObject enemyIcon;

    private void Awake()
    {
        _instance = this;
        playerIcon = transform;
    }

    public Transform GetPlayerPos()
    {
        return playerIcon;
    }

    public GameObject GetBossIcon()
    {
        GameObject go = NGUITools.AddChild(transform.parent.gameObject, enemyIcon);
        go.GetComponent<UISprite>().spriteName = "BossIcon";
        return go;
    }
    
    public GameObject GetMonIcon()
    {
        GameObject go = NGUITools.AddChild(transform.parent.gameObject, enemyIcon);
        go.GetComponent<UISprite>().spriteName = "EnemyIcon";
        return go;
    }
}
