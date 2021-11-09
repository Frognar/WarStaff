using UnityEngine;

public class MoveRb : MonoBehaviour {
  [SerializeField] float speed;
  MoveDirection direction;
  Rigidbody2D rb;
  Vector2 moveAmount;

  void Awake() {
    direction = GetComponent<MoveDirection>();
    rb = GetComponent<Rigidbody2D>();
  }

  void Update() {
    moveAmount = direction.MoveDirection.normalized * speed;
  }

  void FixedUpdate() {
    rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
  }
}
