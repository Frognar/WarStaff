using UnityEngine;

namespace Frognar {
  [RequireComponent(typeof(Rigidbody2D))]
  public class MoveRb : MonoBehaviour {
    Rigidbody2D rb;
    [SerializeField] FloatVariable speed;
    Vector2 moveDirection;

    public void SetDirection(Vector2 direction) {
      moveDirection = direction;
    }

    void Awake() {
      rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
      rb.MovePosition(rb.position + moveDirection * (speed.Value * Time.fixedDeltaTime));
    }
  }
}