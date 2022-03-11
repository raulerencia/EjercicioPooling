using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody _rigidbody;
    private float hp = 1;
    public Image hpBar;
    public GameObject restartButton;

    public Transform gun;
    public int bulletType;

    float actualValue = 1f; // the goal
    float startValue = 1f; // animation start value
    float displayValue = 0f; // value during animation
    float timer = 0f;

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
        timer += Time.deltaTime;
        hpBar.fillAmount = Mathf.Lerp(startValue, actualValue, timer);

        if(hpBar.fillAmount <= 0f){
            restartButton.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other) {
        RestarHP(0.1f);
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

    private void RestarHP(float vida){
        actualValue -= vida;
        timer = 0f;
        startValue = hpBar.fillAmount;
    }


    /*float actualValue = 0f; // the goal
    float startValue = 0f; // animation start value
    float displayValue = 0f; // value during animation
    float timer = 0f;

    // animate the value from startValue to actualValue using displayValue over time using timer. (needs to be called every frame in Update())
    timer += Time.deltaTime;
    displayValue = Mathf.Lerp(startValue, actualValue, timer);
    mask.fillAmount = displayValue; */
}
