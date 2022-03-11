using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed;

    Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector3(1,0,0) * bulletSpeed;
    }

    private void OnCollisionEnter(Collision other) {
        this.gameObject.SetActive(false);
    }
}
