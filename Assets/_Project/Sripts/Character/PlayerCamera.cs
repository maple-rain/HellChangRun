using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform lookAt;
    [SerializeField] Vector3 offset;
    [SerializeField] float cameraSpeed;

    private void Start()
    {
        transform.position = lookAt.position + offset;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = lookAt.position + offset;
        desiredPosition.x = 0.5f;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * cameraSpeed); 
    }
}
