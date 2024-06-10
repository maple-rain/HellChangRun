using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform player;
    [SerializeField] Animator animator;
    [SerializeField] GameObject weaponPrefab;
    [SerializeField] Transform throwPoint;

    [Header("Movement Settings")]
    [SerializeField] float catchDistance = 1f;
    [SerializeField] float throwDistance = 5f;
    [SerializeField] float speed = 6f;

    private float throwTimer;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        transform.position = new Vector3(0.5f, 0f, -5f);
        throwTimer = Random.Range(10f, 15f);
    }

    private void Update()
    {
        if (player != null)
        {
            FollowPlayer();

            if (Mathf.Abs(transform.position.z - player.position.z) <= catchDistance)
            {
                Debug.Log("Game Over!");
                //SceneManager.LoadScene("GameOverScene");
            }

            
            throwTimer -= Time.deltaTime;
            if (throwTimer <= 0f)
            {
                ThrowWeapon();
                throwTimer = Random.Range(4f, 7f); 
            }
        }
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, player.position.z), speed * Time.deltaTime);
        animator.SetFloat("Moving", speed);
    }
    private void ThrowWeapon()
    {
        // 무기를 던지는 애니메이션 트리거
        animator.SetTrigger("ThrowAnimation"); // 정확한 트리거 이름 사용

        // 던지기 애니메이션 시간이 지난 후에 무기를 던짐
        StartCoroutine(ThrowWeaponAfterAnimation());
    }

    private IEnumerator ThrowWeaponAfterAnimation()
    {
        // 애니메이션 길이만큼 대기
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // 무기를 생성하고 던짐
        GameObject weapon = Instantiate(weaponPrefab, throwPoint.position, Quaternion.identity);

        // Rigidbody가 있는지 확인하고, 있으면 속도 설정
        Rigidbody weaponRb = weapon.GetComponent<Rigidbody>();
        if (weaponRb != null)
        {
            weaponRb.velocity = new Vector3(0f, 0f, 25f);
        }
        else
        {
            Debug.LogError("Weapon prefab does not have a Rigidbody component!");
        }

        // 5초 후에 무기 제거
        Destroy(weapon, 5f);

        // 달리는 상태로 돌아감
        animator.SetFloat("Moving", speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player caught!");
            //게임 오버
        }
    }
}