using TMPro;
using UnityEngine;

public class RemoveCube : MonoBehaviour
{
    [SerializeField] private AudioClip getCubeSfx;
    private AudioSource audio;
    private Renderer cubeRenderer;

    [SerializeField] private TMP_Text puzzleInfoText; // UI 텍스트
    public static int itemCount = 0; // 전역 카운트 변수 (static으로 모든 큐브에 공유)

    void Start()
    {
        audio = GetComponent<AudioSource>();
        cubeRenderer = GetComponent<Renderer>(); // 큐브의 Renderer 가져오기
    }

    // 트리거 진입 감지
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 물체의 태그가 "Player"일 경우
        if (other.CompareTag("Player"))
        {

            // 먼저 큐브를 화면에서 보이지 않게 설정
            if (cubeRenderer != null)
            {
                cubeRenderer.enabled = false; // 큐브의 Renderer를 비활성화하여 안 보이게 처리
            }

            // 오디오 재생
            audio.PlayOneShot(getCubeSfx, 0.8f);

            // 오디오가 끝난 후 큐브를 삭제
            Destroy(gameObject, getCubeSfx.length);

            // 카운트 증가
            itemCount += 1;
            string msg = "Puzzle Pieces: " + itemCount;
            puzzleInfoText.text = msg; // UI 업데이트
        }
    }
}
