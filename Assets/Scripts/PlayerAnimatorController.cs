using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Bewegung prüfen (WASD oder Pfeiltasten)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool isWalking = Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f;

        animator.SetBool("isWalking", isWalking);

        // Sprung Trigger setzen
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            animator.SetTrigger("Jump");
        }
    }
}