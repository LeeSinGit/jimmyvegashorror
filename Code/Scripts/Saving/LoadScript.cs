using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScript : MonoBehaviour
{

    public GameObject loadButton;
    public int loadInt;



    void Start()
    {
        loadInt = PlayerPrefs.GetInt("AutoSave");
        if (loadInt > 0)
        {
            loadButton.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
