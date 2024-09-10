using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 물체의 태그가 "Player"일 경우
        if (other.CompareTag("Player"))
        {
            LoadScene();
        }
    }


    public void LoadScene()
    {

        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "SampleScene")
        {
            SceneManager.LoadScene("JYScene");
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        }

        if (currentSceneName == "JYScene")
        {
            SceneManager.LoadScene("AHS_Scene");
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        }

        if (currentSceneName == "AHS_Scene")
        {
            SceneManager.LoadScene("01_Title");
        }
    }
}
