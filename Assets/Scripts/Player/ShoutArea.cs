using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Slowing down");
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.SlowDown();
            
        }
    }
}
