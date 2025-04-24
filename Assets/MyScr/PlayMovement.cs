using UnityEngine;

public class PlayMovement : MonoBehaviour
{
   public float moveSpeed = 5f;
   
       private Rigidbody rb;
       private Vector3 moveDirection;
   
       void Start()
       {
           rb = GetComponent<Rigidbody>();
       }
   
       void Update()
       {
           // รับค่า input จาก WASD
           float moveX = Input.GetAxisRaw("Horizontal"); // A/D
           float moveZ = Input.GetAxisRaw("Vertical");   // W/S
   
           // กำหนดทิศทางการเคลื่อนที่
           moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
       }
   
       void FixedUpdate()
       {
           // เคลื่อนที่ในทิศทางที่กำหนด โดยใช้ความเร็ว
           rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
       }
}
