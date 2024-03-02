using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class GlobalHealth : MonoBehaviour
{


    public int CurrentHealth = 20;
    public int InternalHealth;


    void Update()
    {
        InternalHealth = CurrentHealth;
        if (CurrentHealth <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
