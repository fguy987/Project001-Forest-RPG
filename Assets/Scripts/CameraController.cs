using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to manage the movement of the camera
/// </summary>

public class CameraController : MonoBehaviour
{
    private Camera m_camera;  
    private Transform playerTransform;

    private Vector3 offset;

    private void Awake()
    {
        m_camera = GetComponent<Camera>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Start()
    {
        offset = new Vector3(0, 2, -5);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
    }
}
