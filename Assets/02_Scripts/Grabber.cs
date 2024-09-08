using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectedObject;
    public float snapDistance = 0.5f; // 스냅 거리
    public Transform[] snapPoints;    // 퍼즐 조각이 스냅될 위치들

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null && hit.collider.CompareTag("drag"))
                {
                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            else
            {
                // 드래그가 끝났을 때 스냅 확인
                SnapObject();
                selectedObject = null;
                Cursor.visible = true;
            }
        }

        if (selectedObject != null)
        {
            DragObject();

            if (Input.GetMouseButtonDown(1))
            {
                RotateObject();
            }
        }
    }

    private void DragObject()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        selectedObject.transform.position = new Vector3(worldPosition.x, .25f, worldPosition.z);
    }

    private void RotateObject()
    {
        selectedObject.transform.rotation = Quaternion.Euler(new Vector3(
            selectedObject.transform.rotation.eulerAngles.x,
            selectedObject.transform.rotation.eulerAngles.y + 90f,
            selectedObject.transform.rotation.eulerAngles.z
        ));
    }

    private void SnapObject()
    {
        Transform nearestPoint = GetNearestSnapPoint(selectedObject.transform.position);
        if (nearestPoint != null && Vector3.Distance(selectedObject.transform.position, nearestPoint.position) <= snapDistance)
        {
            // 스냅 위치에 맞추기
            selectedObject.transform.position = nearestPoint.position;
            selectedObject.transform.rotation = nearestPoint.rotation;
        }
    }

    private Transform GetNearestSnapPoint(Vector3 position)
    {
        float nearestDistance = snapDistance;
        Transform nearestPoint = null;

        foreach (Transform point in snapPoints)
        {
            float distance = Vector3.Distance(position, point.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestPoint = point;
            }
        }

        return nearestPoint;
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);

        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
