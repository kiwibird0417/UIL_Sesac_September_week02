using UnityEngine;

public class PuzzleMixer : MonoBehaviour
{
    public GameObject[] puzzlePieces;  // 퍼즐 조각들
    public Transform[] spawnPoints;    // 퍼즐 조각이 놓일 위치들

    void Start()
    {
        MixPuzzle();
    }

    void MixPuzzle()
    {
        // 위치 목록을 무작위로 섞기 위한 배열 생성
        Transform[] shuffledSpawnPoints = ShuffleArray(spawnPoints);

        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            // 각 퍼즐 조각을 랜덤한 위치에 배치
            if (i < shuffledSpawnPoints.Length)
            {
                puzzlePieces[i].transform.position = shuffledSpawnPoints[i].position;
                puzzlePieces[i].transform.rotation = shuffledSpawnPoints[i].rotation;
            }
        }
    }

    Transform[] ShuffleArray(Transform[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Transform temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
        return array;
    }
}
