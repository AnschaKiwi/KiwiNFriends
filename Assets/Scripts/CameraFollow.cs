using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;     // Das ist Anscha Kiwi
    public Vector3 offset;       // Abstand und Winkel zur Figur
    public float smoothSpeed = 5f;

    void Start()
    {
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}

