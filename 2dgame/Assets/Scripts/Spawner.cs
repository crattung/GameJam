
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    float randx;
    Vector2 wheretospawn;
        public float spawnpersec = 1f;
    float nextspawn = 0.0f;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextspawn) 
        {
            nextspawn = Time.time + spawnpersec;
                randx = Random.Range(-10f, 10f);
                wheretospawn = new Vector2(randx, transform.position.y);
            Instantiate(enemy, wheretospawn, Quaternion.identity);






        }
    }
}
