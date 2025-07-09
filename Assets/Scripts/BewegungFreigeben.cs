using UnityEngine;

public class BewegungFreigeben : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Zugriff auf die statische Variable im anderen Script
        PlayerAnimatorController.hasStarted = true;
    }
}

