using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 OffsetPosition;

    void LateUpdate()
    {
        Vector3 DesiredPosition = target.position + OffsetPosition;
        transform.position = new Vector3(DesiredPosition.x, OffsetPosition.y, OffsetPosition.z);
    }
}
