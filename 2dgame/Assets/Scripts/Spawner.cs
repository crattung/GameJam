
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private Transform[] spawnPoints;
    public float spawnInterval = 1f;
    float nextspawn = 0.0f;
    [SerializeField] private int enemiesUnlocked = 1;
    public int EnemiesUnlocked { set { enemiesUnlocked = Mathf.Min(value, enemies.Length); } get { return enemiesUnlocked; } }

    //more badge
    [SerializeField] private Transform _player;


    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextspawn) 
        {
            var pointCnt = spawnPoints.Length;
            var enemyCnt = enemies.Length;
            if(pointCnt * enemyCnt * enemiesUnlocked > 0)
            {
                nextspawn = Time.time + spawnInterval;
                //randx = Random.Range(-10f, 10f);
                var wheretospawn = SpawnPoint();
                var enemy = enemies[Random.Range(0, enemiesUnlocked)];
                Instantiate(enemy, wheretospawn, Quaternion.identity);
            }
        }
    }
    Vector2 SpawnPoint()
    {
        int i = Random.Range(0, spawnPoints.Length);
        if(Vector2.Distance(spawnPoints[i].position, _player.position) < 10)
        {
            i++;
            if(i >= spawnPoints.Length)
                i = 0;
        }
        return spawnPoints[i].position;
    }
}
