using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public MapItemScriptableObject mapItemScriptableObject;

    public LayerMask layerMask;

    private void Update()
    {
        // ���� ������Ʈ ��ġ���� �ణ ���� �÷��� �Ʒ� �������� ���� ����
        Ray ray = new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down);

        // ���̰� ���̾� ����ũ�� �浹���� ������ ���� ������Ʈ�� ����
        if (!Physics.Raycast(ray, out RaycastHit hit, 1f, layerMask))
        {
            Destroy(gameObject);
        }
    }
}
