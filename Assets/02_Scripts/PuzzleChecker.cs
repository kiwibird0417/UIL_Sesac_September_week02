using UnityEngine;
using UnityEngine.SceneManagement;
public class PuzzleChecker : MonoBehaviour
{
    public GameObject[] puzzlePieces;    // 퍼즐 조각들
    public Transform[] correctPositions; // 각 퍼즐 조각이 놓여야 할 정확한 위치들

    private void Update()
    {
        if (IsPuzzleSolved())
        {
            Debug.Log("Puzzle Solved!");
            SceneManager.LoadScene("SampleScene");
            // 게임 완료 로직을 추가할 수 있습니다 (예: 승리 화면으로 전환)
        }
    }

    bool IsPuzzleSolved()
    {
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (!IsPieceInCorrectPosition(puzzlePieces[i], correctPositions[i]))
            {
                return false;
            }
        }
        return true;
    }

    bool IsPieceInCorrectPosition(GameObject piece, Transform correctPosition)
    {
        // 위치를 비교할 때 오차를 두는 것이 좋습니다
        float positionTolerance = 0.1f; // 오차 범위 (필요에 따라 조정 가능)
        float rotationTolerance = 5.0f; // 회전 오차 범위 (필요에 따라 조정 가능)

        // 위치 비교
        if (Vector3.Distance(piece.transform.position, correctPosition.position) > positionTolerance)
        {
            return false;
        }

        // 회전 비교 (EulerAngles를 이용한 간단한 회전 비교)
        Vector3 pieceRotation = piece.transform.rotation.eulerAngles;
        Vector3 correctRotation = correctPosition.rotation.eulerAngles;

        if (Mathf.Abs(pieceRotation.x - correctRotation.x) > rotationTolerance ||
            Mathf.Abs(pieceRotation.y - correctRotation.y) > rotationTolerance ||
            Mathf.Abs(pieceRotation.z - correctRotation.z) > rotationTolerance)
        {
            return false;
        }

        return true;
    }
}
