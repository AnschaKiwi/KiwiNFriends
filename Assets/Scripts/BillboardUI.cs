using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    void LateUpdate()
    {
        // Canvas dreht sich immer zur Kamera
        if (Camera.main != null)
        {
            transform.LookAt(transform.position + Camera.main.transform.forward);
        }
    }
}

