using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.9f;
    public float gravity = -9.81f;
    public float jumpForce = 5f;
    public Transform cameraTransform;

    private CharacterController controller;
    private float verticalVelocity = 0f;
    private Animator animator;

    private bool isJumping = false;
    private float jumpCooldown = 0.2f;
    private float jumpTimer = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Countdown für Sprungverhinderung
        jumpTimer -= Time.deltaTime;

        // Eingabe abfragen
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(h, 0f, v);

        // Kamera-Richtung auswerten
        Vector3 camForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 camRight = Vector3.Scale(cameraTransform.right, new Vector3(1, 0, 1)).normalized;

        Vector3 moveDirection = (camForward * input.z + camRight * input.x).normalized;

        // Figur ausrichten
        if (moveDirection.magnitude > 0.1f)
        {
            transform.forward = moveDirection;
        }

        // Sprung auslösen (nur wenn erlaubt)
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded && !isJumping && jumpTimer <= 0f)
        {
            verticalVelocity = jumpForce;
            isJumping = true;
            jumpTimer = jumpCooldown;
            animator.SetTrigger("Jump");
        }

        // Gravitation
        if (controller.isGrounded)
        {
            if (isJumping)
                isJumping = false;

            if (verticalVelocity < 0f)
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
