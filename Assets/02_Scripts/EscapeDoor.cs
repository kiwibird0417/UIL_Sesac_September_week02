using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class EscapeDoor : MonoBehaviour
{
    [SerializeField] private TMP_Text warningInfoText;

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 물체의 태그가 "Player"일 경우
        if (other.CompareTag("Player"))
        {
            // RemoveCube 클래스의 itemCount 변수를 참조하여 큐브 갯수를 체크
            if (RemoveCube.itemCount >= 4)
            {
                // 탈출 가능한 로직을 작성
                Debug.Log("탈출 성공! 문이 열립니다.");
                SceneManager.LoadScene("01_Title"); //SampleScene");
                //SceneManager.LoadScene("Player", LoadSceneMode.Additive);

                //Load시 퍼즐 씬이 제대로 실행되지 않는 버그...왜 그런지 알 수 없음.
                //SceneManager.LoadScene("Puzzle");
            }
            else
            {
                // 큐브 갯수가 부족할 때
                Debug.Log("큐브가 부족합니다. 더 모아야 탈출할 수 있습니다.");
                string msg = "Not Enough Cubes!";
                warningInfoText.text = msg; // UI 업데이트
            }
        }
    }
}
