using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class RaycastLuz : MonoBehaviour
{
    public int rango;
    public Camera camara;
    public Text mensajeTexto; // Referencia al objeto Texto en UI
    private bool mostrarMensaje; // Para controlar la visibilidad del mensaje

    void Start()
    {
        mensajeTexto.enabled = false;
        mostrarMensaje = false;
    }

    void Update()
    {
        RaycastHit hit;

        // Usamos la cámara principal o la cámara asignada
        Camera cam = (camara != null) ? camara : Camera.main;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rango))
        {
            Luz luzComponent = hit.collider.GetComponent<Luz>();
            if (luzComponent != null && luzComponent.luz)
            {
                // Mostrar mensaje para presionar "E"
                mostrarMensaje = true;

                // Si se presiona "E", apagar la luz
                if (Input.GetKeyDown(KeyCode.E))
                {
                    luzComponent.OnOffLuz();
                    mostrarMensaje = false; // Ocultar mensaje después de apagar la luz
                }
            }
            else
            {
                mostrarMensaje = false; // Ocultar mensaje si no está cerca del objeto con luz
            }
        }
        else
        {
            mostrarMensaje = false; // Ocultar mensaje si no hay rayo de colisión
        }

        mensajeTexto.enabled = mostrarMensaje;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rango);
    }
}
