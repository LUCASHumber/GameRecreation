using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SideScrollingCamera : MonoBehaviour
{

    public Transform trackedObject;
    public float height = 6.5f;

    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(cameraPosition.x, trackedObject.position.x);
        transform.position = cameraPosition;
    }

}
