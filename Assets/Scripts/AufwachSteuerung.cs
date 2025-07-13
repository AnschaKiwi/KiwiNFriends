using UnityEngine;

public class AufwachSteuerung : MonoBehaviour
{
    public Animator animator;
    private bool istAufgewacht = false;
    public bool skipAufstehen = false;

    void Update()
    {
        if (!istAufgewacht && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Aufstehen");
            istAufgewacht = true;
        }
    }
}

