using UnityEngine;

public class AufwachSteuerung : MonoBehaviour
{
    public Animator animator;
    private bool istAufgewacht = false;

    void Update()
    {
        if (!istAufgewacht && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Aufstehen");
            istAufgewacht = true;
        }
    }
}

