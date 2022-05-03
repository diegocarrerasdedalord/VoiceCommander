using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public float damage; //esto deberia estar en powers y powers deberia llamarse otra cosa que tenga mas sentido con esa skill
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
        if(other.tag=="Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.currentHP -= damage*Time.deltaTime;
        }
    }
}
