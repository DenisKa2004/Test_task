using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawRotator : MonoBehaviour
{
    [Header("Скорость вращения")]
    [SerializeField]
    private float rotationSpeed = 100f;

    [Header("Объект jaw")]
    [SerializeField]
    private Transform jaw;


    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            RotateAroundPivot(rotationSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.Y))
        {
            RotateAroundPivot(0, rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            RotateAroundPivot(0, 0, rotationSpeed * Time.deltaTime);
        }
    }

    void RotateAroundPivot(float xRotation, float yRotation, float zRotation)
    {
        jaw.Rotate(xRotation, yRotation, zRotation, Space.Self);
    }
}
