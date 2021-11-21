using UnityEngine;

namespace Frognar {
  public class MoveAnimator : MonoBehaviour {
    Animator animator;

    void Awake() {
      animator = GetComponent<Animator>();
    }

    public void SetIsRunning(bool isRunning) {
      animator.SetBool("isRunning", isRunning);
    }
  }
}