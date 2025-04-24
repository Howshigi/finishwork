using UnityEngine;

public class MouseLock : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;  // กำหนดเป็นตัวละครที่หมุนซ้าย-ขวา

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // รับค่าจากเมาส์
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // หมุนตัวละครซ้าย-ขวา (แกน Y)
        playerBody.Rotate(Vector3.up * mouseX);

        // จำกัดการหมุนกล้องก้ม/เงย (แกน X)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // แค่หมุนในแนวดิ่ง (X)
    }
}
