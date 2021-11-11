using UnityEngine;

namespace Frognar {
  public class Movement : MonoBehaviour {
    MoveDirection moveDirection;
    MoveAnimator moveAnimator;
    MoveRb move;

    void Awake() {
      moveDirection = GetComponent<MoveDirection>();
      moveAnimator = GetComponent<MoveAnimator>();
      move = GetComponent<MoveRb>();
    }

    void Update() {
      move.SetDirection(moveDirection.Direction);
      moveAnimator.SetIsRunning(moveDirection.Direction.sqrMagnitude > 0f);
    }
  }
}