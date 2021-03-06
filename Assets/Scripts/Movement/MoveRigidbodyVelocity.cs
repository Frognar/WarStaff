using UnityEngine;

namespace Frognar {
  [RequireComponent(typeof(Rigidbody2D), typeof(MoveAnimator))]
  public class MoveRigidbodyVelocity : MonoBehaviour, MoveVelocity {
    [SerializeField] FloatVariable moveSpeed;
    MoveAnimator moveAnimator;
    Rigidbody2D rigidBody;
    Vector3 velocity;

    void Awake() {
      rigidBody = GetComponent<Rigidbody2D>();
      moveAnimator = GetComponent<MoveAnimator>();
    }

    public void SetVelocity(Vector3 velocity) {
      this.velocity = velocity;
    }

    void FixedUpdate() {
      rigidBody.velocity = velocity * moveSpeed.Value;
      moveAnimator.SetIsRunning(velocity != Vector3.zero);
    }
  }
}
