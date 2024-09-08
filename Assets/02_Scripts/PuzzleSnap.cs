using UnityEngine;

public class PuzzleSnap : MonoBehaviour
{
    public Transform[] snapPoints;    // 퍼즐 조각이 스냅될 위치들
    public float snapDistance = 0.5f; // 스냅 거리 (퍼즐 조각이 이 거리 이내에 있으면 스냅됨)

    private void Update()
    {
        SnapToNearestPoint();
    }

    void SnapToNearestPoint()
    {
        float nearestDistance = snapDistance;
        Transform nearestPoint = null;

        foreach (Transform point in snapPoints)
        {
            float distance = Vector3.Distance(transform.position, point.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestPoint = point;
            }
        }

        if (nearestPoint != null && nearestDistance <= snapDistance)
        {
            // 스냅 위치에 맞추기
            transform.position = nearestPoint.position;
            transform.rotation = nearestPoint.rotation;
        }
    }
}
