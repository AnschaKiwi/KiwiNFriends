using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.9f;
    public float gravity = -9.81f;
    public Transform cameraTransform; // Bezug zur Kamera für Richtung

    private CharacterController controller;
    private float verticalVelocity = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Eingabe abfragen
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(h, 0f, v);

        // Kamera-Richtung auswerten (Y ignorieren)
        Vector3 camForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 camRight = Vector3.Scale(cameraTransform.right, new Vector3(1, 0, 1)).normalized;

        // Bewegung relativ zur Kamera berechnen
        Vector3 moveDirection = (camForward * input.z + camRight * input.x).normalized;

        // Figur ausrichten
        if (moveDirection.magnitude > 0.1f)
        {
            transform.forward = moveDirection;
        }

        // Schwerkraft
        if (controller.isGrounded)
        {
            verticalVelocity = 0f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        // Bewegung zusammensetzen
        Vector3 finalMovement = moveDirection * speed;
        finalMovement.y = verticalVelocity;

        controller.Move(finalMovement * Time.deltaTime);
    }
}
