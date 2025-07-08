using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 7.5f;
    public float zoomSpeed = 7f;
    public float minZoom = 1f;
    public float maxZoom = 10f;
    public float rotationSpeed = 300f;

    private float currentZoom = 6f;
    private float currentYaw = 0f;
    private float currentPitch = 8f; // Startwinkel nach unten

    // Basis-Offset für Blickwinkel und Entfernung
    private Vector3 baseOffset = new Vector3(0f, 3f, -6f);

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

        // Abstand und Rotation berechnen
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);
        Vector3 zoomedOffset = baseOffset.normalized * currentZoom;
        Vector3 rotatedOffset = rotation * zoomedOffset;

        // Zielposition auf Kopfhöhe
        Vector3 targetHeadPos = target.position + Vector3.up * 1.5f;
        Vector3 desiredPosition = targetHeadPos + rotatedOffset;

        // Weiches Nachführen der Kamera
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(targetHeadPos);
    }
}
