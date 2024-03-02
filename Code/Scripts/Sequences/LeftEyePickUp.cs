using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftEyePickUp : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject LeftEye;


    public GameObject halfFade;
    public GameObject eyeImg;
    public GameObject eyeText;
    


    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 7)
        {
            ExtraCross.SetActive (true);
            ActionText.GetComponent<Text>().text = "Поднять левый глаз";
            ActionDisplay.SetActive (true);
            ActionText.SetActive (true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 7)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive (false);
                ActionText.SetActive (false);
                ExtraCross.SetActive (false);
                GlobalInventory.leftEye = true;
                StartCoroutine(EyePickedUP());
            }
        }
    }

    void OnMouseExit()
    {
        ExtraCross.SetActive (false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }


    IEnumerator EyePickedUP()
    {
        halfFade.SetActive(true);
        eyeImg.SetActive(true);
        eyeText.SetActive(true);
        yield return new WaitForSeconds(4);
        halfFade.SetActive(false);
        eyeImg.SetActive(false);
        eyeText.SetActive(false);
        LeftEye.SetActive(false);
    }

}
