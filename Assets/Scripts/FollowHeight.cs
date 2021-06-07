using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class FollowHeight : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        Vector3 newTransform = transform.position;
        newTransform.y = Target.position.y;
        transform.position = newTransform;
    }
}
