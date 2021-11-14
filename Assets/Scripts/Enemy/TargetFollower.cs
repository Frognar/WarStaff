using UnityEngine;

namespace Frognar {
  [RequireComponent(typeof(TargetFinder))]
  public class TargetFollower : MonoBehaviour, MoveDirection {
    Transform target;
    TargetFinder targetFinder;
    [SerializeField] FloatVariable stopDistance;
    public Vector2 Direction { get; private set; }

    void Awake() {
      targetFinder = GetComponent<TargetFinder>();
    }

    void Start() {
      target = targetFinder.FindTarget();
    }

    void Update() {
      if (target != null && Vector2.Distance(transform.position, target.position) > stopDistance.Value) {
        Direction = (target.position - transform.position).normalized;
      }
      else {
        Direction = Vector2.zero;
      }
    }
  }
}