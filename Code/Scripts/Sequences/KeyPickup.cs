using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject TheKey;




    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ExtraCross.SetActive (true);
            ActionText.GetComponent<Text>().text = "Поднять ключ";
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
                TheKey.SetActive(false);
                GlobalInventory.firstDoorKey = true;
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
