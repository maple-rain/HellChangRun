using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    private Transform playCharacter;

    private void Update()
    {
        Vector3 newPosition = this.transform.position;
        newPosition.z = playCharacter.position.z - 20;
        this.transform.position = newPosition;
    }

}
