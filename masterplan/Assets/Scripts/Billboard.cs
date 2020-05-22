using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Camera referenceCamera;

    void Awake()
    {
        // if no camera referenced, grab the main camera
        if (!referenceCamera)
            referenceCamera = Camera.main;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + referenceCamera.transform.rotation * Vector3.forward, referenceCamera.transform.rotation* Vector3.up);
    }
}
