using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.9f;
    private CharacterController controller;
    public float gravity = -9.81f;
    private float verticalVelocity = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            verticalVelocity = 0f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        Vector3 moveDirection = new Vector3(h, 0, v);

        if (moveDirection.magnitude > 0.1f)
        {
            transform.forward = moveDirection;
        }

        moveDirection.y = verticalVelocity;
        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}
