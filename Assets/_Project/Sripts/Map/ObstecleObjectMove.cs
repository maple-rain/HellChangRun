using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstecleObjectMove : MonoBehaviour
{
    public float speed = 2f;  // �ʱ� �ӵ� ���� ����
    private float maxX = 8f;  // �ִ� X ��ǥ ���� ����
    private float minX = -8f; // �ּ� X ��ǥ ���� ����
    private float direction = 1f;  // �̵� ������ ���� (1�� ������, -1�� ����)
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
            direction = -1f;  // ������ ���� �����ϸ� �������� �̵�
        }
        else if (rb.transform.position.x <= minX)
        {
            direction = 1f;  // ���� ���� �����ϸ� ���������� �̵�
        }

        rb.velocity = new Vector3(direction * speed, 0, 0);

        // �߰�: Rigidbody�� �ӵ��� 0���� �ʱ�ȭ
        rb.velocity = new Vector3(direction * speed, rb.velocity.y, rb.velocity.z);
    }
}

