using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    public GameObject luzObjeto;

    public bool luz;

    private bool luzOnOff;

    public void OnOffLuz()
    {
        luzOnOff = !luzOnOff;

        if(luzOnOff == true)
        {
            luzObjeto.SetActive(true);
        }
        if(luzOnOff == false)
        {
            luzObjeto.SetActive(false);
        }
    }
}
