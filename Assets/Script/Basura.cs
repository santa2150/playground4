using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class Basura : MonoBehaviour
{
    public int numDeObjetivos;

    private void Start()
    {
        numDeObjetivos = GameObject.FindGameObjectsWithTag("Objetivo").Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Objetivo")
        {
            Destroy(other.transform.parent.gameObject);
            numDeObjetivos--;
        }
    }
}
