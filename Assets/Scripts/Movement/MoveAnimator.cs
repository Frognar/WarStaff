using UnityEngine;

namespace Frognar {
  [RequireComponent(typeof(Animator))]
  public class MoveAnimator : MonoBehaviour {
    Animator animator;
    bool isRunning;

    void Awake() {
      animator = GetComponent<Animator>();
    }

    public void SetIsRunning(bool isRunning) {
      if (this.isRunning != isRunning) {
        this.isRunning = isRunning;
        animator.SetBool("isRunning", isRunning);
      }
    }

    void OnEnable() {
      isRunning = false;
    }
  }
}