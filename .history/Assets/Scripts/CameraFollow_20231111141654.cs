using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private float smoothing;
    [SerializeField]private Transform target;

    void LateUpdate()
    {
        Vector2 pos = Vector2.Lerp(transform.position, target.position, smoothing);
        transform.position = pos;
    }
}
