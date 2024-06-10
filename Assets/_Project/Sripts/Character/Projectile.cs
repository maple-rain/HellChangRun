using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // 플레이어의 위치를 변경합니다.
            PlayerController playerController = collision.collider.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.HandleProjectileHit();
            }

            // 투사체를 제거합니다.
            Destroy(gameObject);
        }
    }
}