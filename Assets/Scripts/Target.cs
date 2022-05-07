using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            manager.LoadNextLevel();
        }
    }
}

