using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstecleObjectMove : MonoBehaviour
{
    public float speed = 2f;  // 초기 속도 값을 설정
    private float maxX = 8f;  // 최대 X 좌표 값을 설정
    private float minX = -8f; // 최소 X 좌표 값을 설정
    private float direction = 1f;  // 이동 방향을 설정 (1은 오른쪽, -1은 왼쪽)
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        if (rb.transform.position.x >= maxX)
        {
            direction = -1f;  // 오른쪽 끝에 도달하면 왼쪽으로 이동
        }
        else if (rb.transform.position.x <= minX)
        {
            direction = 1f;  // 왼쪽 끝에 도달하면 오른쪽으로 이동
        }

        rb.velocity = new Vector3(direction * speed, 0, 0);

        // 추가: Rigidbody의 속도를 0으로 초기화
        rb.velocity = new Vector3(direction * speed, rb.velocity.y, rb.velocity.z);
    }
}

