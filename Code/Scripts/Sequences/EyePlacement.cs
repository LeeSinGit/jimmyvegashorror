using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyePlacement: MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject eyePieces;
    public GameObject realWall;
    public AudioSource wallUp;



    


    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (GlobalInventory.leftEye == true && GlobalInventory.rightEye == true)
        {
            if (TheDistance <= 3)
            {
                ExtraCross.SetActive (true);
                ActionText.GetComponent<Text>().text = "Установить изображение на место";
                ActionDisplay.SetActive (true);
                ActionText.SetActive (true);
            }
            if (Input.GetButtonDown("Action"))
            {
                if (TheDistance <= 3)
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive (false);
                    ActionText.SetActive (false);
                    ExtraCross.SetActive (false);
                    eyePieces.SetActive(true);
                    realWall.GetComponent<Animator>().Play("RealRise");
                    wallUp.Play();
                }
            }
        }
    }

    void OnMouseExit()
    {
        ExtraCross.SetActive (false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

}
