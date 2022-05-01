using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Raycast : MonoBehaviour
{
    public static Raycast instance;
    public float daño;
    public float distanciaMaxima;
    public ParticleSystem flare;
    public GameObject sangre;
    public int maxAmmo;
    public int currentAmmo;
    public int extraAmmo;
    public float reloadTime;
    public float currentReloadTime;
    public bool isReloading = false;
    public Text currentAmmoText;
    public Text extraAmmoText;
    Animator anim;
    public Camera camara;
    public GameObject sonidoRecarga;
    public GameObject sonidoDisparo;
    public void Awake()
    {
        anim = GetComponent<Animator>();
        instance = this;
    }
    public void Update()
    {
        //////currentAmmoText.text = currentAmmo.ToString() + ("/") + extraAmmo.ToString();
        //extraAmmoText.text = extraAmmo.ToString();
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        if (Input.GetKeyDown(KeyCode.Mouse0) && isReloading == false && currentAmmo > 0)
        {

            currentAmmo--;
            RaycastHit hitInfo;
            //bool hit = Physics.Raycast(camara.transform.position, camara.transform.forward, out hitInfo, distanciaMaxima);
            //Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range
            flare.Play();
            GameObject newSonidoDisparo = Instantiate(sonidoDisparo, transform.position, transform.rotation);


            if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hitInfo, distanciaMaxima))
            {
                //////Vida vida = hitInfo.transform.GetComponent<Vida>(); ESTO LO COMENTE PORQUE NO TENGO VIDA IMPLEMENTADA TODAVIA

                //////if (vida != null)
                //////{
                //////    Instantiate(sangre, hitInfo.point, Quaternion.identity);
                //////    vida.vidaTotal -= daño;
                //////}

            }
            //  Debug.Log(hitInfo.transform.forward);
        }
        if (Input.GetKeyDown(KeyCode.R) && isReloading == false && extraAmmo > 0 && currentAmmo < maxAmmo)
        {
            anim.SetBool("Reloading", true);
            currentReloadTime = reloadTime;
            isReloading = true;
            GameObject newSonido = Instantiate(sonidoRecarga, transform.position, transform.rotation);
            Reload();

        }
        if (isReloading == true)
        {
            currentReloadTime -= Time.fixedDeltaTime;
            if (currentReloadTime <= 0)
            {
                isReloading = false;
                anim.SetBool("Reloading", false);
            }


        }

    }
    public void Reload()
    {
        int shot = maxAmmo - currentAmmo;
        if (extraAmmo < shot)
        {
            currentAmmo += extraAmmo;
            extraAmmo = 0;
        }
        else
        {
            currentAmmo += shot;
            extraAmmo -= shot;
        }

    }



}


