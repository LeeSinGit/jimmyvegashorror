using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLight : MonoBehaviour
{
    public int LightMode;
    public GameObject FlameLight;

    void Update ()
    {
        if (LightMode == 0)
        {
            StartCoroutine(RandomizeLightLamp());
        }
    }

    IEnumerator RandomizeLightLamp()
    {
        LightMode = Random.Range(1, 4);
        if (LightMode == 1)
        {
            FlameLight.GetComponent<Animation>().Play("LampAnim");
        }
        if (LightMode == 2)
        {
            FlameLight.GetComponent<Animation>().Play("LampAnim2");
        }
        if (LightMode == 3)
        {
            FlameLight.GetComponent<Animation>().Play("LampAnim3");
        }
        yield return new WaitForSeconds(2f);
        LightMode = 0;
    }


}
