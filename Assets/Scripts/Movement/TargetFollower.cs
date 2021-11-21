using UnityEngine;

namespace Frognar {
  [RequireComponent(typeof(TargetFinder))]
  public class TargetFollower : MonoBehaviour {
    Transform target;
    TargetFinder targetFinder;
    MoveVelocity moveVelocity;
    [SerializeField] FloatVariable stopDistance;

    void Awake() {
      moveVelocity = GetComponent<MoveVelocity>();
      targetFinder = GetComponent<TargetFinder>();
    }

    void Start() {
      target = targetFinder.FindTarget();
    }

    void Update() {
      if (target != null && Vector2.Distance(transform.position, target.position) > stopDistance.Value) {
        moveVelocity.SetVelocity((target.position - transform.position).normalized);
      }
      else {
        moveVelocity.SetVelocity(Vector2.zero);
      }
    }
  }
}