using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class GameManager : MonoBehaviour
{
    public Light2D lt;
    public bool lightcheck;
    private void Start()
    {
        StartCoroutine(LightSettings());
    }
    
    IEnumerator LightSettings()
    {
        yield return new WaitForSeconds(5);
        lt.GetComponent<Light2D>().lightType = Light2D.LightType.Global;
        lightcheck=true;
        yield return new WaitForSeconds(1);
        lt.GetComponent<Light2D>().lightType = Light2D.LightType.Point;
        lightcheck=false;
        Movement.FindObjectOfType<Movement>().check=false;
        StartCoroutine(LightSettings());
    }
}
