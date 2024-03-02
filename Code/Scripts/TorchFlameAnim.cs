using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlameAnim : MonoBehaviour
{

    public int LightMode;
    public GameObject FlameLight;


    void Update()
    {
        if (LightMode == 0)
        {
            StartCoroutine(AnimateLight());
        }    
    }

    IEnumerator AnimateLight ()
    {
        LightMode = Random.Range(1, 4);
        if (LightMode == 1)
        {
            FlameLight.GetComponent<Animation>().Play("TorchLightAnim");
        }
        if (LightMode == 2)
        {
            FlameLight.GetComponent<Animation>().Play("TorchLightAnim2");
        }
        if (LightMode == 3)
        {
            FlameLight.GetComponent<Animation>().Play("TorchLightAnim3");
        }

        yield return new WaitForSeconds(2f);
        LightMode = 0;
    }
}
