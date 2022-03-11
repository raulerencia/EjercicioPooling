using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed;

    Rigidbody _rigidbody;
    public Transform gun;

    public int enemyBulletPrefab;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("ShootRepeating",waitTime, waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector3(-1f,0,0) * speed;
    }

    private void OnCollisionEnter(Collision other) {
        //StopCoroutine("Shoot");
        this.gameObject.SetActive(false);
    }

    /*public IEnumerator Shoot(){
        
        GameObject newEnemyBullet = PoolManager.instance.GetPooledObject(enemyBulletPrefab);
        newEnemyBullet.transform.position = gun.position;
        newEnemyBullet.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine("Shoot");
    }*/

    private void ShootRepeating(){
        GameObject newEnemyBullet = PoolManager.instance.GetPooledObject(enemyBulletPrefab);
        newEnemyBullet.transform.position = gun.position;
        newEnemyBullet.SetActive(true);
    }
}
