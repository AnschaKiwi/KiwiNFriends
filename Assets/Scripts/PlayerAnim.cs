using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    public static bool hasStarted = false; // Spielstartstatus

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        hasStarted = false;
    }

    void Update()
    {
        // Spielstart nur bei Space
        if (!hasStarted && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Aufstehen");
        }

        if (!hasStarted)
        {
            animator.SetBool("isWalking", false);
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool isWalking = Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f;

        animator.SetBool("isWalking", isWalking);

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            animator.SetTrigger("Jump");
        }
    }
}
