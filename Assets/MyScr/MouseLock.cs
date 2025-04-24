using UnityEngine;

public class MouseLock : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // รับค่าการเคลื่อนที่ของเมาส์
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // ก้ม/เงยกล้อง (แกน X)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // จำกัดมุมก้มเงย

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // หมุนตัวละครตามแกน Y
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
