using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    public CharacterController player;

    public float PlayerSpeed = 5f;
    public float mouseSensitivity = 10f;

    private float verticalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor al centro de la pantalla
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento del jugador
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        // Rotación de la cámara con el mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Aplicar rotación horizontal al jugador
        transform.Rotate(Vector3.up * mouseX);

        // Aplicar rotación vertical a la cámara
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Limitar la rotación vertical

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void FixedUpdate()
    {
        // Mover al jugador en base a las entradas de movimiento
        Vector3 moveDirection = transform.forward * verticalMove + transform.right * horizontalMove;
        player.Move(moveDirection * PlayerSpeed * Time.deltaTime);
    }
}
