using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject TheGun;
    public GameObject MuzzleFlash;
    public AudioSource GunFire;
    public GameObject PointLight;
    public bool IsFiring = false;
    public float TargetDistance;
    public int DamageAmount = 5;
    public GameObject RealPistol;
    public bool pistolIsUp = false;
    public bool pistolIsDown = false;
    public GameObject player;

    void Update()
    {
        if (RealPistol.activeSelf && Input.GetButtonDown("Fire1") && GlobalAmmo.ammoCount >= 1)
        {
            if (IsFiring == false)
            {
                GlobalAmmo.ammoCount -= 1;
                StartCoroutine(FiringPistol());
            }
        }

        StartCoroutine(ControlPistol());


    }

    IEnumerator FiringPistol ()
    {
        RaycastHit Shot;
        IsFiring = true;
        if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            Shot.transform.SendMessage ("DamageObject", DamageAmount, SendMessageOptions.DontRequireReceiver);
            Shot.transform.SendMessage ("DamageBox", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }
        TheGun.GetComponent<Animation>().Play("PistolShot");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnim");
        PointLight.SetActive(true);
        GunFire.Play();
        yield return new WaitForSeconds(0.5f);
        PointLight.SetActive(false);
        IsFiring = false;
    }

    IEnumerator ControlPistol ()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit))
        {
            float distance = hit.distance;
            if (distance <= 1.6f && pistolIsUp == false)
            {
                yield return new WaitForSeconds(0.1f);
                TheGun.GetComponent<Animation>().Play("PistolAndWall");
                pistolIsUp = true;
                pistolIsDown = false;
            }
            else if (distance > 1.6f && pistolIsUp == true && pistolIsDown == false)
            {
                yield return new WaitForSeconds(0.5f);
                TheGun.GetComponent<Animation>().Play("PistolAndWallDown");
                pistolIsDown = true;
                pistolIsUp = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            other.GetComponent<ArionDigital.CrashCrate>().DamageBox(DamageAmount);
        }
    }

}
