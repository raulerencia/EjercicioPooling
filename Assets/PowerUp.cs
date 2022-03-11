using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Desactivar");
    }

    private IEnumerator Desactivar(){
        yield return new WaitForSeconds(20f);
        this.gameObject.SetActive(false);
    }
    
}
