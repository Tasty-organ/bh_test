using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance = null;

    private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -5);
    [SerializeField] private float verticalLimit = 70f;
    [SerializeField] private float horizontalSensitivity = 30f;
    [SerializeField] private float verticalSensitivity = 30f;
    private float mouseX, mouseY;

    private void Awake()
    {
        if (!instance) instance = this;
        else throw new System.Exception();
    }

    public void SetFollowTarget(Transform target)
    {
        this.target = target;
        transform.position = target.position + offset;
    }

    private void LateUpdate()
    {
        if (!target) return;
        mouseX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * horizontalSensitivity;
        mouseY += Input.GetAxis("Mouse Y") * verticalSensitivity;
        mouseY = Mathf.Clamp(mouseY, -verticalLimit, verticalLimit);
        transform.localEulerAngles = new Vector3(-mouseY, mouseX, 0);
        transform.position = transform.localRotation * offset + target.position;
    }
}
