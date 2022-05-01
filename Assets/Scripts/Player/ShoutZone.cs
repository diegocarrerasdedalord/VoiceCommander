using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutZone : MonoBehaviour
{
    public GameObject particles;
    public  GameObject box; //puede que tenga que poner un new aca
    ScaleFromMicrophone microphoneScale;
    // Start is called before the first frame update
    void Start()
    {
        microphoneScale = FindObjectOfType<ScaleFromMicrophone>();
    }

    // Update is called once per frame
    void Update()
    {
        if (box.transform.localScale.x > microphoneScale.maxScale.x / 3) //esto funciona mal deberia tener particulas que se encienden mas rapido o hacer que se queden encendidas por mas que se achique la caja
        {
            particles.SetActive(true);
        }
        else
        {
            particles.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //si el tamaño del collider supera a X entonces dejar que pueda ralentizar y spawnear efecto de particulas
            //esto se hace para que no se active con solo decir dracarys
            if (box.transform.localScale.x > (microphoneScale.maxScale.x) / 1.5f)
            {
                Debug.Log("Slowing down");
                Enemy enemy = other.GetComponent<Enemy>();
                enemy.SlowDown();
            }
        }
    }
}
