using UnityEngine;

public class MouseController2D : MonoBehaviour {
  [Header("Movement Settings")]
  public float speed = 10f;

  [Header("References")]
  public MouseSpawner originSpawner;

  private Rigidbody2D rb;
  private Vector2 movement;

  void Start() {
    rb = GetComponent<Rigidbody2D>();
    rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    if (originSpawner != null) {
      float spawnerAngle = originSpawner.transform.eulerAngles.z;
      float minAngle = spawnerAngle - 15f;
      float maxAngle = spawnerAngle + 15f;

      movement = GetRandomDirection(minAngle, maxAngle);
    } else {
      movement = GetRandomDirection();
    }
  }

  void FixedUpdate() {
    rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    RotatePlayer(movement.x, movement.y);
  }

  void OnCollisionEnter2D(Collision2D collision) {
    movement = GetRandomDirection();
  }

  void OnCollisionStay2D(Collision2D collision) {
    movement = GetRandomDirection();
  }

  void OnDestroy() {
    if (originSpawner != null) {
      originSpawner.DecreaseMouseCount();
    }
  }

  void RotatePlayer(float x, float y) {
    if (x == 0 && y == 0) return;

    float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0, 0, angle);
  }

  Vector2 GetRandomDirection(float minAngle = 0f, float maxAngle = 360f) {
    float angle = Random.Range(minAngle, maxAngle);
    return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
  }
}
