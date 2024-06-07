using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public MapItemScriptableObject mapItemScriptableObject;

    public LayerMask layerMask;

    private void Update()
    {
        // 현재 오브젝트 위치에서 약간 위로 올려서 아래 방향으로 레이 생성
        Ray ray = new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down);

        // 레이가 레이어 마스크와 충돌하지 않으면 현재 오브젝트를 삭제
        if (!Physics.Raycast(ray, out RaycastHit hit, 1f, layerMask))
        {
            Destroy(gameObject);
        }
    }
}
