using UnityEngine;

namespace Frognar {
  public class Movement : MonoBehaviour {
    protected MoveDirection moveDirection;
    protected MoveAnimator moveAnimator;
    protected MoveRb move;

    protected virtual void Awake() {
      moveDirection = GetComponent<MoveDirection>();
      moveAnimator = GetComponent<MoveAnimator>();
      move = GetComponent<MoveRb>();
    }

    protected virtual void Update() {
      move.SetDirection(moveDirection.Direction);
      moveAnimator.SetIsRunning(moveDirection.Direction.sqrMagnitude > 0f);
    }
  }
}