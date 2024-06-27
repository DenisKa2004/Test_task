using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothController : MonoBehaviour
{
    [Header("Скорость перемещения")]
    [SerializeField]
    private float moveSpeed = 10.0f;

    [Header("Скорость приближения/отдаления")]
    [SerializeField]
    public float zoomSpeed = 10.0f;

    private bool isMoving = false;
    private Transform selectedTooth;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("tooth"))
            {
                selectedTooth = hit.transform;
                selectedTooth.parent = null;
                isMoving = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
            selectedTooth = null;
        }

        if (isMoving && selectedTooth != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(-mainCamera.transform.forward, selectedTooth.position);
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 worldPosition = ray.GetPoint(distance);
                selectedTooth.position = worldPosition;
            }
        }

        if (selectedTooth != null)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            Vector3 direction = (selectedTooth.position - mainCamera.transform.position).normalized;
            selectedTooth.position += direction * scroll;
        }
    }

}
