using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemy;
    public Transform spawn;
    public float waitTime;
    public float waitTimePowerUp;
    public int enemyPrefab;
    public int powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
        StartCoroutine("SpawnPowerUp");
    }

    IEnumerator SpawnEnemy(){
        yield return new WaitForSeconds(waitTime);
        GameObject newEnemy = PoolManager.instance.GetPooledObject(enemyPrefab);
        newEnemy.transform.position = new Vector3(spawn.position.x, spawn.position.y, Random.Range(-10, 10));
        newEnemy.SetActive(true);
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnPowerUp(){
        yield return new WaitForSeconds(waitTimePowerUp);
        GameObject newPowerUP = PoolManager.instance.GetPooledObject(powerUpPrefab);
        newPowerUP.transform.position = new Vector3(spawn.position.x, spawn.position.y, Random.Range(-10, 10));
        newPowerUP.SetActive(true);
        StartCoroutine("SpawnPowerUp");
    }
    
}
