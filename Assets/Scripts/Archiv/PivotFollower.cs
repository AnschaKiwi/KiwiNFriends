using UnityEngine;

public class PivotFollower : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position;
        }   
    }
}
