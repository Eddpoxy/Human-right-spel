using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // The target to follow
    public float smoothSpeed = 0.125f; // The smoothness of the camera follow

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
