using UnityEngine;

public class TomMovement : MonoBehaviour {
    public float speed = 5f;
    public bool canMoveDiagonally = true;

    // Private variables
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isMovingHorizontally = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update() {
      float horizontalInput = Input.GetAxisRaw("Horizontal");
      float verticalInput = Input.GetAxisRaw("Vertical");

      if (canMoveDiagonally) {
        movement = new Vector2(horizontalInput, verticalInput);
        RotatePlayer(horizontalInput, verticalInput);
      } else {
        if (horizontalInput != 0) {
          isMovingHorizontally = true;
        } else if (verticalInput != 0) {
          isMovingHorizontally = false;
        }

        if (isMovingHorizontally) {
          movement = new Vector2(horizontalInput, 0);
          RotatePlayer(horizontalInput, 0);
        } else {
          movement = new Vector2(0, verticalInput);
          RotatePlayer(0, verticalInput);
        }
      }
    }

    void FixedUpdate() {
      rb.linearVelocity = movement * speed;
    }

    void RotatePlayer(float x, float y) {
      if (x == 0 && y == 0) return;

      float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}
