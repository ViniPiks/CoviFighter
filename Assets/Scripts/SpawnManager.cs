using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject player;
    public GameObject enemyPr;
    private GameObject[] enemyCount;
    public int enemyCountWave = 25;
    public float maxRadius = 20;
    public float minRadius = 5;
    private float randomNumberForRay = 10;
    
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyCount.Length<enemyCountWave)
        {
            spawnEnemy();
        }

    }

    void spawnEnemy()
    {
        float rangeRandomNumberForRayX = Random.Range(-randomNumberForRay, randomNumberForRay);
        float rangeRandomNumberForRayZ = Random.Range(-randomNumberForRay, randomNumberForRay);
        Vector3 direction = new Vector3(rangeRandomNumberForRayX, 0, rangeRandomNumberForRayZ);
        Ray spawnRay = new Ray(player.transform.position, direction);
        Vector3 spawnPos = player.transform.position + spawnRay.direction * (Random.Range(minRadius, maxRadius));
        Instantiate(enemyPr, spawnPos, enemyPr.transform.rotation);
    }
}
      
    
