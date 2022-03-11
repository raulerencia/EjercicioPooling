using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody _rigidbody;
    
    public Transform gun;
    public int bulletType;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(0f, 0f, -horizontal).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //_rigidbody.MovePosition(direction.normalized * speed * Time.deltaTime);
            transform.position += direction * speed * Time.deltaTime;

            if(transform.position.z > 10){
                transform.position = new Vector3(-1,0, 10);
            }else if(transform.position.z < -10){
               transform.position = new Vector3(-1,0, -10); 
            }
        }

        if(Input.GetButtonDown("Jump")){
            GameObject bullet = PoolManager.instance.GetPooledObject(bulletType);
            bullet.transform.position = gun.position;
            bullet.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag.Equals("PowerUp")){
            StartCoroutine("DoubleVelocity");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("PowerUp")){
            StartCoroutine("DoubleVelocity");
            other.gameObject.SetActive(false);
        }
    }

    public IEnumerator DoubleVelocity(){

        speed = speed * 1.5f;
        yield return new WaitForSeconds(5f);
        speed = speed/1.5f;
    }
}
