using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    public GameObject monster;
    public float spawnPause = 5f;
    public int maxMonsters = 10;
    private float spawnTimer = 0f;
    private bool spawnWait = false;
    
    private List<Transform> spawners = new List<Transform>();
    private GameObject monsterBox;
    
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            spawners.Add(transform.GetChild(i));            
        }

        monsterBox = new GameObject("monsterBox");
        monsterBox.transform.parent = gameObject.transform;
    }

    void FixedUpdate()
    {
        if (spawnWait)
        {
            if (spawnTimer > spawnPause)
            {
                spawnWait = false;
                return;
            }

            spawnTimer += Time.fixedDeltaTime;
            return;
        }
        if (monsterBox.transform.childCount >= maxMonsters)
            return;

        spawnTimer = 0f;
        spawnWait = true;

        foreach (var spawner in spawners)
        {
            StartCoroutine(Spawn(spawner.position));
        }
    }
    
    private IEnumerator Spawn(Vector3 v)
    {
        if (monsterBox.transform.childCount < maxMonsters)
            Instantiate(monster, v, Quaternion.identity, monsterBox.transform);
        yield return null;
    }
}
