using UnityEngine;

public class MoveAnimator : MonoBehaviour {
  Animator animator;
  MoveDirection direction;

  void Awake() {
    direction = GetComponent<MoveDirection>();
    animator = GetComponent<Animator>();
  }

  void Update() {
    bool isRunning = direction.MoveDirection != Vector2.zero;
    animator.SetBool("isRunning", isRunning);
  }
}