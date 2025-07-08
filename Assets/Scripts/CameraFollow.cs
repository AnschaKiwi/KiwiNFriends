using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 5f;
    public float zoomSpeed = 7f;
    public float minZoom = 2f;
    public float maxZoom = 15f;
    public float rotationSpeed = 200f;

    private float currentZoom;
    private float currentYaw = 0f;
    private float currentPitch = 8f; // Startwinkel nach unten

    void Start()
    {
        currentZoom = offset.magnitude;
        transform.position = target.position + offset;
        transform.LookAt(target);
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Zoom mit Mausrad
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= scroll * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // Kamera-Rotation mit rechter Maustaste
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            currentYaw += mouseX * rotationSpeed * Time.deltaTime;
            currentPitch -= mouseY * rotationSpeed * Time.deltaTime;
            currentPitch = Mathf.Clamp(currentPitch, -10f, 80f); // Begrenzung für Pitch
        }

        // Jetzt Pitch und Yaw verwenden!
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0);
        Vector3 rotatedOffset = rotation * (offset.normalized * currentZoom);

        // Zielposition auf Kopfhöhe (z.B. 2 Einheiten über dem Boden)
        Vector3 targetHeadPos = target.position + Vector3.up * 2f;
        Vector3 desiredPosition = targetHeadPos + rotatedOffset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(targetHeadPos);
    }
}

