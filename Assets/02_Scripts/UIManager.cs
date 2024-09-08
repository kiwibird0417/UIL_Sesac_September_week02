using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//08.23(금)
public class UIManager : MonoBehaviour
{
    // 버튼을 할당할 변수 선언
    public Button startButton;


    void OnEnable()
    {
        // 이벤트 연결
        startButton.onClick.AddListener(() => OnStartButtonClick());
    }


    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);
    }

}
