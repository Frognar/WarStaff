using UnityEngine;

namespace Frognar {
  public class SummonAnimator : MonoBehaviour {
    Animator animator;

    void Awake() {
      animator = GetComponent<Animator>();
    }

    public void PlaySummonAnimation() {
      animator.SetTrigger("summon");
    }
  }
}
