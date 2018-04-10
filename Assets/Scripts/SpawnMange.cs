using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMange : MonoBehaviour {
    public EnemySpawn [] MonsterSpawnArray;
    public EnemySpawn [] BossSpawnArray;
    public AudioClip victorySound;
    public static SpawnMange _instance;
    public List<GameObject> enemyList = new List<GameObject>();
    // Use this for initialization
    private void Awake()
    {
        _instance = this;
    }

    void Start () {
        StartCoroutine(Spawn());
	}
	
    IEnumerator Spawn()
    {
        //第一波敌人
        foreach(EnemySpawn s in MonsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }
        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        //第二波敌人
        foreach (EnemySpawn s in MonsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }
        yield return new WaitForSeconds(0.5f);
        foreach (EnemySpawn s in MonsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }
        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        //第三波敌人
        foreach (EnemySpawn s in MonsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }
        foreach(EnemySpawn s in BossSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }
        yield return new WaitForSeconds(0.5f);
        foreach (EnemySpawn s in MonsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }
        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        AudioSource.PlayClipAtPoint(victorySound, transform.position, 1f);
    }
}
