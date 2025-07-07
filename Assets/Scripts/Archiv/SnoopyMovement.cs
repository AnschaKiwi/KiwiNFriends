using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SnoopyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform cameraRig;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Eingabe lesen (WASD oder Pfeiltasten)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(h, 0f, v).normalized;

        if (inputDir.magnitude >= 0.1f)
        {
            // Kamera-Rotation als Basis nehmen
            Vector3 forward = cameraRig.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = cameraRig.right;
            right.y = 0;
            right.Normalize();

            // Richtung berechnen
            Vector3 moveDir = forward * v + right * h;
            controller.Move(moveDir * moveSpeed * Time.deltaTime);
        }
    }
}
