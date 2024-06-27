using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Скорость перемещения")]
    [SerializeField]
    private float speed = 10.0f;

    [Header("Чувствительность мыши")]
    [SerializeField]
    private float sensitivity = 5.0f;

    private float rotationY = 0.0f;
    private float rotationX = 0.0f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivity;
            rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);

            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            direction = transform.TransformDirection(direction);
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
