using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Bewegung prüfen (WASD oder Pfeiltasten)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool isWalking = Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f;

        animator.SetBool("isWalking", isWalking);
    }
}