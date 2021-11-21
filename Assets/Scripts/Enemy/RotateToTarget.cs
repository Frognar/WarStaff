using UnityEngine;

namespace Frognar {
  public class RotateToTarget : MonoBehaviour {
    TargetFinder targetFinder;
    Rotate rotate;

    void Awake() {
      targetFinder = GetComponentInParent<TargetFinder>();
      rotate = GetComponent<Rotate>();
    }

    void Update() {
      if (targetFinder.HasTarget()) {
        rotate.SetPoint(targetFinder.FindTarget().position);
      }
      else {
        rotate.SetPoint(Vector3.zero);
      }
    }
  }
}
