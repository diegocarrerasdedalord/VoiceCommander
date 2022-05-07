using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    //drakarys variables
    public GameObject fireKillZone;
    public GameObject fireParticles;
    public float fireCooldown;
    public float fireActiveTime;
    public float fireDuration;
    
    public float maxMana;
    public float currentMana;
    public float manaCost;

    
    public bool spitFireIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
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
        if (fireActiveTime>fireCooldown&& manaCost<=currentMana)
        {
            fireActiveTime = 0;
            fireKillZone.SetActive(true);
            fireParticles.SetActive(true);
            spitFireIsActive = true;
            currentMana -= manaCost;
        }
    }

    public void DisableSpitFire()
    {
        fireKillZone.SetActive(false);
        fireParticles.SetActive(false);
        spitFireIsActive = false;
    }

    
}
