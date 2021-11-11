using UnityEngine;

namespace Frognar {
  public class MoveAnimator : MonoBehaviour {
    Animator animator;
    bool isRunning;

    public void SetIsRunning(bool isRunning) {
      this.isRunning = isRunning;
    }

    void Awake() {
      animator = GetComponent<Animator>();
    }

    void Update() {
      animator.SetBool("isRunning", isRunning);
    }
  }
}