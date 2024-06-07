using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XInput;

public class GuardChase : MonoBehaviour
{
    public Transform player; 
    public GameObject projectilePrefab; // 투사체 프리팹
    public Transform throwPoint; // 투사체가 발사될 위치
    public float catchDistance = 1.5f; // 잡히는 거리
    public float throwInterval = 8f; // 투사체를 던지는 간격
    public float followDistance = 5f; // 보안관이 플레이어를 따라오는 거리
    public float speed = 10f; // 보안관의 이동 속도

    private NavMeshAgent navAgent; // NavMeshAgent 
    private Animator animator; // Animator 
    private float throwTimer; // 투사체 던지기 타이머

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        throwTimer = throwInterval; // 타이머 초기화
    }

    void Update()
    {
        if (player != null)
        {
            // 플레이어의 좌우 이동을 따라갑니다.인풋컨트롤러 사용시 주석 해제
            //Vector3 move = new Vector3(InputController.MoveInput.x, 0, InputController.MoveInput.y) * speed * Time.deltaTime;
            //navAgent.Move(move);
            Vector3 followPosition = new Vector3(player.position.x, transform.position.y, player.position.z - followDistance);
            navAgent.SetDestination(followPosition);


            // 보안관의 속도에 따라 애니메이션을 조정
            animator.SetFloat("Speed", navAgent.velocity.magnitude);

            if (Vector3.Distance(transform.position, player.position) <= catchDistance)
            {
                Debug.Log("플레이어 잡힘");
                // 게임 오버 처리 또는 다른 로직 추가
            }

            // 일정 시간마다 투사체를 던집니다.
            throwTimer -= Time.deltaTime;
            if (throwTimer <= 0f)
            {
                ThrowProjectile();
                throwTimer = throwInterval; // 타이머 리셋
            }
        }
    }

    void ThrowProjectile()
    {
        // 투사체 생성 및 발사
        GameObject projectile = Instantiate(projectilePrefab, throwPoint.position, throwPoint.rotation);
        // 투사체에 플레이어를 향해 회전하도록 설정
        projectile.transform.LookAt(player.position);
        Debug.Log("덤밸 던짐");
    }
}
