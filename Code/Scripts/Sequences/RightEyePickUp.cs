using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightEyePickUp : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject RightEye;


    public GameObject halfFade;
    public GameObject eyeImg;
    public GameObject eyeText;
    

    public GameObject fakeWall;
    public GameObject realWall;


    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 7)
        {
            ExtraCross.SetActive (true);
            ActionText.GetComponent<Text>().text = "Поднять правый глаз";
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
                GlobalInventory.rightEye = true;
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
        fakeWall.SetActive(false);
        realWall.SetActive(true);
        ActionText.GetComponent<Text>().text = "Вы нашли оба глаза";
        halfFade.SetActive(true);
        eyeImg.SetActive(true);
        eyeText.SetActive(true);
        yield return new WaitForSeconds(4);
        halfFade.SetActive(false);
        eyeImg.SetActive(false);
        eyeText.SetActive(false);
        RightEye.SetActive(false);
    }

}
