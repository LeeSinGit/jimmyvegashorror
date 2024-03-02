using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPicker : MonoBehaviour
{

    public GameObject theAmmo;
    public GameObject ammoDisplayBox;

    private void OnTriggerEnter(Collider other)
    {
        ammoDisplayBox.SetActive(true);
        GlobalAmmo.ammoCount += 6;
        gameObject.SetActive(false);
    }

}
