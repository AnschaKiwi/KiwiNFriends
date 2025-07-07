using UnityEngine;
using Unity.Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineCamera cineCam;

    [Tooltip("Zoomgrenzen (Field of View)")]
    public float minFov = 1f;
    public float maxFov = 60f;
    public float zoomSpeed = 1f;
float targetFov;

void Start()
{
    if (cineCam != null)
        targetFov = cineCam.Lens.FieldOfView;
}

void Update()
{
    if (cineCam == null) return;

    // Mausrad-Input verarbeiten → Zielwert verändern
    float scroll = Input.mouseScrollDelta.y;
    targetFov -= scroll * zoomSpeed;
    targetFov = Mathf.Clamp(targetFov, minFov, maxFov);

    // FOV abrufen, weich annähern
    var lens = cineCam.Lens;
    lens.FieldOfView = Mathf.Lerp(lens.FieldOfView, targetFov, Time.deltaTime * 8f); // <- 8 = Weichheit
    cineCam.Lens = lens;
}

}
