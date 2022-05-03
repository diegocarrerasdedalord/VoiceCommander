using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    //drakarys variables
    public GameObject fireKillZone;
    public GameObject fireParticles;
    public float fireCooldown;
    public float fireActiveTime=60;
    public float fireDuration;

    
    public bool spitFireIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireActiveTime += Time.deltaTime;
        if(spitFireIsActive=true&&fireActiveTime>fireDuration)
        {
            DisableSpitFire();
        }
    }

    public void Alakazam()
    {

    }

    public void SpitFire()
    {
        if (fireActiveTime>fireCooldown)
        {
            fireActiveTime = 0;
            fireKillZone.SetActive(true);
            fireParticles.SetActive(true);
            spitFireIsActive = true;
        }
    }

    public void DisableSpitFire()
    {
        fireKillZone.SetActive(false);
        fireParticles.SetActive(false);
        spitFireIsActive = false;
    }

    
}
