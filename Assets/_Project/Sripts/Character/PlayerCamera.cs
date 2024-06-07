using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform lookAt;
    [SerializeField] Vector3 offset;

    private void Start()
    {
        transform.position = lookAt.position + offset;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = lookAt.position + offset;
        desiredPosition.x = 4;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime); 
    }
}
