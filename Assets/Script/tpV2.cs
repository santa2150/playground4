using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpV2 : MonoBehaviour
{
    public Transform Destino;

    void Update()
    {
        // Verifica si se ha presionado la tecla "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Busca el objeto con la etiqueta "Player"
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                // Desactiva el CharacterController para evitar problemas de colisión durante el teletransporte
                CharacterController controller = player.GetComponent<CharacterController>();
                if (controller != null)
                {
                    controller.enabled = false;
                }

                // Teletransporta al jugador al destino
                player.transform.position = Destino.position;

                // Vuelve a activar el CharacterController después del teletransporte
                if (controller != null)
                {
                    controller.enabled = true;
                }
            }
        }
    }
}

