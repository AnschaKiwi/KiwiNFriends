using UnityEngine;
using Unity.Cinemachine;

public class CameraTargetSetter : MonoBehaviour
{
    [Tooltip("Die neue CinemachineCamera mit Follow + LookAt")]
    public CinemachineCamera cineCam;

    public void SetFollowTarget(Transform target)
    {
        if (cineCam != null && target != null)
        {
            cineCam.Follow = target;
            cineCam.LookAt = target;
        }
    }
}

