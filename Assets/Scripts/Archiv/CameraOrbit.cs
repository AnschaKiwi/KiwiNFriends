using UnityEngine;
using Unity.Cinemachine;

public class CameraOrbit : MonoBehaviour
{
    public CinemachineCamera cineCam;
    public float rotationSpeed = 100f;

    private float yaw = 0f;

    void Update()
    {
        if (cineCam == null) return;

        if (Input.GetMouseButton(1)) // rechte Maustaste
        {
            float mouseX = Input.GetAxis("Mouse X");
            yaw += mouseX * rotationSpeed * Time.deltaTime;

            // Hole das Follow-Offset
            var followComponent = cineCam.GetComponent<CinemachineFollow>();
            if (followComponent != null)
            {
                Vector3 offset = Quaternion.Euler(0, yaw, 0) * new Vector3(0, 2f, -6f);
                followComponent.FollowOffset = offset;
            }
        }
    }
}

    

