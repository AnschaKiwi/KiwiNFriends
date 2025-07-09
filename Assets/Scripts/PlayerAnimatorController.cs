using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    public static bool hasStarted = false; // <-- static!

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Spielstart nur bei W oder Leertaste
        if (!hasStarted && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            hasStarted = true;
            animator.SetBool("hasStarted", true);
            // animator.SetTrigger("Start");
        }

        if (!hasStarted)
        {
            animator.SetBool("isWalking", false);
            return; // Alles andere wird übersprungen!
        }

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